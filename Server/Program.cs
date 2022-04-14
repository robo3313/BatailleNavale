
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public static void Main()
    {

        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("192.168.43.8");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            // Enter the listening loop.
            while (true)
            {
                Console.Write("Je suis le serveur... ");

                // Perform a blocking call to accept requests.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Process the coordinates sent sent by the client.

                    switch (data)
                    {
                        case "No message":
                            // Send a missile.
                            Console.WriteLine("Entrer une postition à attaquer");
                            string missile = Console.ReadLine()!;
                            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(missile!);
                            stream.Write(msg2, 0, msg2.Length);
                            Console.WriteLine("Sent: {0}", missile);
                            break;
                        case "hit":
                            break;
                        case "not hit":
                            break;
                        default:
                        // Check if the oppponent hit something
                        data = "hit"; //or not

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                            break;


                    }

/*
                    if (data != "No message")
                    {
                        // Check if the oppponent hit something
                        data = "hit"; //or not

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                    // Send a missile.
                    else
                    {
                        if(data =="hit" || data == "not hit") continue; // Updating my map
                        Console.WriteLine("Entrer une postition à attaquer");
                        string missile = Console.ReadLine()!;
                        byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(missile!);
                        stream.Write(msg2, 0, msg2.Length);
                        Console.WriteLine("Sent: {0}", missile);
                    }


                    */

break;
                }
               // Console.WriteLine("on est sorti de la boucle");

                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
{
    Console.WriteLine("SocketException: {0}", e);
}
finally
{
    // Stop listening for new clients.
    server.Stop();
}

Console.WriteLine("\nHit enter to continue...");
Console.Read();

    }

}