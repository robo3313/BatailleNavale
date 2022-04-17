using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Jeu;

namespace Networking
{
    public class Client
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[4096];
        Socket? sender;
        NavalMessage Response = new();
        Engine Engine = new();

        public Client()
        {
            Engine.AddBoat("Un", "U", new string[] { "F6", "F7", "F8" });
            Engine.AddBoat("Deux", "D", new string[] { "G6", "G7", "G8" });
            /*Engine.AddBoat("Trois", "T", new string[] { "H6", "H7", "H8" });
            Engine.AddBoat("Quatre", "Q", new string[] { "I6", "I7", "I8" });
            Engine.AddBoat("Cinq", "C", new string[] { "J6", "J7", "J8" });*/
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
                            throw new Exception("Your opponent attacked in "+ Response.Position + " and you list !");
                            break;
                    }
                    break;
            }
            return true;
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

        public void DisplayGrids()
        {
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
            DisplayGrids();
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
    }
}
