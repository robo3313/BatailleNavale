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
        byte[] bytes = new byte[1024];
        Socket? sender;


        public void Connect(string ip = "192.168.1.128")
        {
            // Establish the remote endpoint for the socket. This example uses port 11000 on the local computer.  
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.  
            sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
        }

        public int SendMessage(NavalMessage nm)
        {
            // Encode the data string into a byte array.
            string jsonString = JsonSerializer.Serialize(nm);
            byte[] msg = Encoding.ASCII.GetBytes(jsonString + "<EOF>");
            // Send the data through the socket.  
            return sender.Send(msg);
        }

        public string WaitResponse()
        {
            string res;
            int bytesRec;
            
            Console.WriteLine("Waiting for Server response...");
            // Receive the response from the remote device.  
            bytesRec = sender.Receive(bytes);
            res = Trim(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            Console.WriteLine("Received Server response: {0}", res);
            return res;
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

    }
}
