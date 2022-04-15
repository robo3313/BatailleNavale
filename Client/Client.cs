using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Networking
{
    public class Client
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];
        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint remoteEP;
        Socket sender;


        public void Connect(string ip = "192.168.1.128")
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            ipAddress = IPAddress.Parse(ip);
            remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.  
            sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
        }


        public void SendMessage(string message)
        {
            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(message+"<EOF>");

            // Send the data through the socket.  
            int bytesSent = sender.Send(msg);

            // Receive the response from the remote device.  
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

        }

        public void End()
        {
            // Release the socket.  
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

    }
}
