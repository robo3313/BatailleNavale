using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Jeu;

namespace Jeu.Network
{
    public class Server
    {
        public static void StartServer()
        {
            Server server = new();
            int gameState = 0;

            while (true)
            {
                try
                {
                    server.WaitConnection();
                    server.setupFleet();
                    //Waiting for a player
                    server.WaitResponse();
                    server.HandleResponse();
                    server.SendFleet();
                    while (server.WaitResponse() && gameState != 2)
                    {
                        server.HandleResponse();
                        server.Attack();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Incoming data from the client.  
        public static string data = null;
        IPEndPoint localEndPoint;
        Socket listener;
        Socket? handler;
        Engine Engine = new();
        NavalMessage Response = new();

        public Server()
        {
            // Establish the local endpoint for the socket. Dns.GetHostName returns the name of the host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress tmp in ipHostInfo.AddressList)
            {
                Console.WriteLine(tmp.MapToIPv4().ToString());
            }
            IPAddress ipAddress = ipHostInfo.AddressList[3];

            localEndPoint = new IPEndPoint(ipAddress, 17000);

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Console.WriteLine("Server initialized, ipAddress: {0}", ipAddress.MapToIPv4());
        }

        public void setupFleet()
        {
            List<int> boatSize = new List<int>() {2,2,3,3,4};
            foreach (int bs in boatSize)
            {
                setupBoat(bs);
            }
        }

        public void setupBoat(int length, string? error = null)
        {
            string[] tmp;
            string[] positions;

            Engine.DisplayGame();
            Console.WriteLine("Place your boat (length {0}) : {1}", length, error);
            try
            {
                tmp = Console.ReadLine().Split(" ");
                positions = tmp[1].Split(",");
                if (positions.Length != length)
                {
                    throw new Exception("Boat size must be "+length);
                }
                Engine.AddBoat(tmp[0], "", positions);
            }
            catch (Exception e)
            {
                setupBoat(length, e.Message);
            }

        }

        public void WaitConnection()
        {
            Console.WriteLine("Waiting for a connection...");
            // Program is suspended while waiting for an incoming connection.  
            handler = listener.Accept();
            Console.WriteLine("New Client connection !");

        }
        public bool WaitResponse()
        {
            byte[] bytes = new Byte[4069];
            string res;

            Console.WriteLine("Waiting for Client message...");
            int bytesRec = handler.Receive(bytes);
            res = Trim(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            //Console.WriteLine("Received Client message: {0}", res);
            Response = JsonSerializer.Deserialize<NavalMessage>(res) ?? NavalMessage.CreateFromError();
            return true;

        }

        public int HandleResponse()
        {
            int tmp = 0;

            switch (Response.Type)
            {
                case 2:
                    Engine.setFleet(new Fleet(Response.Fleet));
                    Engine.DisplayGame();
                    break;
                case 3:
                    tmp = Engine.ReceiveAttack(Response.Position);
                    Engine.DisplayGame();
                    switch (tmp)
                    {
                        case 0:
                            Console.WriteLine("Your oponnent attacked in {0} and missed !", Response.Position);
                            break;
                        case 1:
                            Console.WriteLine("Your opponent attacked in {0} and you were hit !", Response.Position);
                            break;
                        case 2:
                            throw new Exception("Your opponent attacked in " + Response.Position + " and you lost !");
                    }
                    break;
            }
            return tmp;
        }

        public int SendMessage(NavalMessage nm)
        {
            // Encode the data string into a byte array.  
            string jsonString = JsonSerializer.Serialize(nm);
            byte[] msg = Encoding.ASCII.GetBytes(jsonString + "<EOF>");
            // Send the data through the socket.  
            return handler.Send(msg);
        }

        private string Trim(string str)
        {
            return str.Remove(str.IndexOf("<EOF>"));
        }

        public void End()
        {
            //handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        public void SendFleet()
        {
            SendMessage(NavalMessage.CreateFromFleet(Engine.MyFleet));
        }

        public void Attack()
        {
            Position pos;
            string str;
            int tmp;

            Console.WriteLine("Send attack :");
            try
            {
                pos = Position.createFromString(Console.ReadLine());
                tmp = Engine.Attack(pos);
                SendMessage(NavalMessage.CreateFromAttack(pos));
                Engine.DisplayGame();
                switch (tmp)
                {
                    case 0:
                        Console.WriteLine("You attacked {0} and missed !", pos);
                        break;
                    case 1:
                        Console.WriteLine("You attacked {0} hit !", pos);
                        break;
                    case 2:
                        throw new Exception("You attacked " + pos + " and won !");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid attack : {0}", e.Message);
                Attack();
            }
        }

    }
}
