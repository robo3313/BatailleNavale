using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Jeu;

namespace Jeu.Networking
{
    public class Client
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[4096];
        Socket? sender;
        NavalMessage Response = new();
        Engine Engine = new();

        public Client(){}

        public static void StartClient()
        {
            Client client = new();
            bool connected = false;

            while (connected == false)
            {
                try
                {
                    Console.WriteLine("Enter the Server IP Address:");
                    client.Connect(Console.ReadLine());
                    connected = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                client.setupFleet();
                //Ask to build Fleet here
                client.SendFleet();
                client.WaitResponse();
                client.HandleResponse();
                client.Attack();

                while (client.WaitResponse())
                {
                    client.HandleResponse();
                    client.Attack();
                }
                //client.End();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Connect(string ip = "192.168.1.128")
        {
            ip = ip == "" ? "127.0.0.1" : ip;
            // Establish the remote endpoint for the socket. This example uses port 11000 on the local computer.  
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 17000);

            // Create a TCP/IP  socket
            sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
        }

        public void setupFleet()
        {
            List<int> boatSize = new List<int>() { 2, 2, 3, 3, 4 };
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
                    throw new Exception("Boat size must be " + length);
                }
                Engine.AddBoat(tmp[0], "", positions);
            }
            catch (Exception e)
            {
                setupBoat(length, e.Message);
            }

        }

        public int SendMessage(NavalMessage nm)
        {
            // Encode the data string into a byte array.
            string jsonString = JsonSerializer.Serialize(nm);
            //Console.WriteLine("Sending\n{0}", jsonString + "<EOF>");
            byte[] msg = Encoding.ASCII.GetBytes(jsonString + "<EOF>");
            // Send the data through the socket.  
            return sender.Send(msg);
        }

        public bool WaitResponse()
        {
            string res;
            int bytesRec;
            
            Console.WriteLine("Waiting for Server response...");
            // Receive the response from the remote device.  
            bytesRec = sender.Receive(bytes);
            res = Trim(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            //Console.WriteLine("Received Server response: {0}", res);
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
                            throw new Exception("Your opponent attacked in "+ Response.Position + " and you lost !");
                    }
                    break;
            }
            return tmp;
        }

        private string Trim(string str)
        {
            return str.Remove(str.IndexOf("<EOF"));
        }

        public void End()
        {
            // Release the socket.  
            //sender.Shutdown(SocketShutdown.Both);
            sender.Send(Encoding.ASCII.GetBytes("EXIT<EOF>"));
            sender.Close();
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
            catch (ErrorException e)
            {
                Console.WriteLine("Invalid attack : {0}", e.Message);
                Attack();
            }
        }
    }
}
