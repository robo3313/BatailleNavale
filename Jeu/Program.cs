﻿/*using System;
using Jeu.BatailleNavaleGame;
using Jeu.Menus;
using static System.Console;*/

namespace  Jeu
{
    /// <summary>
    /// classe statique pour les constantes
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// constante pour le logo du jeu
        /// </summary>
        public const string _LOGO = @"


 ▄▄▄▄    ▄▄▄     ▄▄▄█████▓ ▄▄▄       ██▓ ██▓     ██▓    ▓█████     ███▄    █  ▄▄▄    ██▒   █▓ ▄▄▄       ██▓    ▓█████       ▄▄▄█████▓ ██░ ██ ▓█████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▐██▌ 
▓█████▄ ▒████▄   ▓  ██▒ ▓▒▒████▄    ▓██▒▓██▒    ▓██▒    ▓█   ▀     ██ ▀█   █ ▒████▄ ▓██░   █▒▒████▄    ▓██▒    ▓█   ▀       ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀     ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀     ▐██▌ 
▒██▒ ▄██▒██  ▀█▄ ▒ ▓██░ ▒░▒██  ▀█▄  ▒██▒▒██░    ▒██░    ▒███      ▓██  ▀█ ██▒▒██  ▀█▄▓██  █▒░▒██  ▀█▄  ▒██░    ▒███         ▒ ▓██░ ▒░▒██▀▀██░▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███       ▐██▌ 
▒██░█▀  ░██▄▄▄▄██░ ▓██▓ ░ ░██▄▄▄▄██ ░██░▒██░    ▒██░    ▒▓█  ▄    ▓██▒  ▐▌██▒░██▄▄▄▄██▒██ █░░░██▄▄▄▄██ ▒██░    ▒▓█  ▄       ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄     ▓██▒ 
░▓█  ▀█▓ ▓█   ▓██▒ ▒██▒ ░  ▓█   ▓██▒░██░░██████▒░██████▒░▒████▒   ▒██░   ▓██░ ▓█   ▓██▒▒▀█░   ▓█   ▓██▒░██████▒░▒████▒        ▒██▒ ░ ░▓█▒░██▓░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒    ▒▄▄  
░▒▓███▀▒ ▒▒   ▓▒█░ ▒ ░░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░ ▒░▓  ░░░ ▒░ ░   ░ ▒░   ▒ ▒  ▒▒   ▓▒█░░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░░ ▒░ ░        ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░    ░▀▀▒ 
▒░▒   ░   ▒   ▒▒ ░   ░      ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░░ ░ ▒  ░ ░ ░  ░   ░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░░    ▒   ▒▒ ░░ ░ ▒  ░ ░ ░  ░          ░     ▒ ░▒░ ░ ░ ░  ░     ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░    ░  ░ 
 ░    ░   ░   ▒    ░        ░   ▒    ▒ ░  ░ ░     ░ ░      ░         ░   ░ ░   ░   ▒     ░░    ░   ▒     ░ ░      ░           ░       ░  ░░ ░   ░      ░ ░   ░   ░   ▒   ░      ░      ░          ░ 
 ░            ░  ░              ░  ░ ░      ░  ░    ░  ░   ░  ░            ░       ░  ░   ░        ░  ░    ░  ░   ░  ░                ░  ░  ░   ░  ░         ░       ░  ░       ░      ░  ░    ░    
      ░                                                                                  ░                                                                                                          
";
        public const string _STRHOST = "en choisissant cette option tu décides d'héberger la partie en attendant qu'un autre joueur te rejoigne";
        public const string _STRPGUEST = "en choisissant cette option tu décides de rejoindre une partie hébergée par un autre joueur";
    }
    /// <summary>
    /// classe correpondant au point d'entrée de l'application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// point d'entrée de l'application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Game myGame = new();
            myGame.Start();

            /*
            Fleet fleet1 = new Fleet();
            fleet1.AddBoat("Willy", "Orque", new string[] { "A1", "A2", "A3" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "D5", "D6", "D7" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "B9", "B10", "B11" });
            */

            /*Fleet f = new();
            Boat b = new("toto", "navire", new string[] { "G5", "G6", "G7"});
            b.WriteInfo();



            Grid g = new();
            g.AddBoat(b);
            g.Display();
            g.AddImpact(i);*/
            /*Fleet f = new();
            Boat b1 = new("Gary", "Galleon");
            Boat b2 = new("William", "Warship");
            b1.WriteInfo();
            b2.WriteInfo();*/
        }
    }



}

/*
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
                Console.Write("Waiting for a connection... ");

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

                    // Process the data sent by the client.
                    
                    data = "hit";

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);

                  

                }
                // Send a missile.

                string missile = "5H";
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(missile);
                stream.Write(msg2, 0, msg2.Length);
                Console.WriteLine("Sent: {0}", missile);

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
*/