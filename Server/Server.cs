using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Jeu;

namespace Network
{
    class Server
    {
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
            IPAddress ipAddress = ipHostInfo.AddressList[1];

            localEndPoint = new IPEndPoint(ipAddress, 17000);

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Console.WriteLine("Server initialized, ipAddress: {0}", ipAddress.MapToIPv4());
            Engine.AddBoat("Un", "U", new string[] { "A3", "A4", "A5" });
            /*Engine.AddBoat("Deux", "D", new string[] { "B3", "B4", "B5" });
            Engine.AddBoat("Trois", "T", new string[] { "C3", "C4", "C5" });
            Engine.AddBoat("Quatre", "Q", new string[] { "D3", "D4", "D5" });
            Engine.AddBoat("Cinq", "C", new string[] { "E3", "E4", "E5" });*/
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

        public bool HandleResponse()
        {
            int tmp;

            switch (Response.Type)
            {
                case 2:
                    Engine.setFleet(new Fleet(Response.Fleet));
                    DisplayGrids();
                    break;
                case 3:
                    tmp = Engine.ReceiveAttack(Response.Position);
                    DisplayGrids();
                    switch (tmp)
                    {
                        case 0:
                            Console.WriteLine("Your oponnent attacked in {0} and missed !", Response.Position);
                            break;
                        case 1:
                            Console.WriteLine("Your opponent attacked in {0} and you were hit !", Response.Position);
                            break;
                        case 2:
                            throw new Exception("Your opponent attacked in "+ Response.Position + " and you lost !");
                            break;
                    }
                    break;
            }
            return true;
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

        public void DisplayGrids()
        {
            Console.Clear();
            Engine.DisplayGrids();
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
            pos = Position.createFromString(Console.ReadLine());
            SendMessage(NavalMessage.CreateFromAttack(pos));
            tmp = Engine.Attack(pos);
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
            DisplayGrids();
        }

    }
}
