using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network
{
    class Server
    {
        // Incoming data from the client.  
        public static string data = null;
        IPEndPoint localEndPoint;
        Socket listener;
        Socket? handler;

        public Server()
        {
            // Establish the local endpoint for the socket. Dns.GetHostName returns the name of the host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];

            localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            listener.Bind(localEndPoint);
            listener.Listen(10);
            Console.WriteLine("Server initialized, ipAddress: {0}", ipAddress.MapToIPv4());
        }

        public void WaitConnection()
        {
            Console.WriteLine("Waiting for a connection...");
            // Program is suspended while waiting for an incoming connection.  
            handler = listener.Accept();
        }
        public string WaitMessage()
        {
            byte[] bytes = new Byte[1024];
            string res;

            Console.WriteLine("Waiting for Client message...");
            int bytesRec = handler.Receive(bytes);
            res = Trim(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            Console.WriteLine("Received Client message: {0}", res);
            return res;
        }

        public int sendMessage(string message)
        {
            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");
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

    }
}
