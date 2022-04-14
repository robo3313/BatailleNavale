
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client;


string JsonSerializeFunction(EnvironmentVariableTarget a)
{
    string jsonString = JsonSerializer.Serialize(a);

    return jsonString;
}

static String Connect(String server, String message = "No message")
{
    String returned = "valeur de retour";
    try
    {
        // Create a TcpClient,TcpServer at IP address 192.168.43.8, port 13000 being created

        Int32 port = 13000;
        TcpClient client = new TcpClient(server, port);

        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        // Get a client stream for reading and writing.
        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer.
        stream.Write(data, 0, data.Length);

        Console.WriteLine("Sent: {0}", message);

        // Receive the TcpServer.response.

        // Buffer to store the response bytes.
        data = new Byte[256];

        // String to store the response ASCII representation.
        String responseData = String.Empty;

        // Read the first batch of the TcpServer response bytes.
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //Console.WriteLine("Received: {0}", responseData);



        /*
        //***********************************************************************
        // Buffer to store the second response bytes.
        Byte[] data2 = new Byte[256];

        // String to store the response ASCII representation.
        String responseData2 = String.Empty;
        // Read the second batch of the TcpServer response bytes.
        Console.WriteLine("on est au batch 2");
        Int32 bytes2 = stream.Read(data2, 0, data2.Length);
        responseData2 = System.Text.Encoding.ASCII.GetString(data2, 0, bytes2);
        Console.WriteLine("Received 2: {0}", responseData2);
        //***********************************************************************
        */
        returned = responseData;


        //Close everything
        stream.Close();
        client.Close();


    }
    catch (ArgumentNullException e)
    {
        Console.WriteLine("ArgumentNullException: {0}", e);
    }
    catch (SocketException e)
    {
        Console.WriteLine("SocketException: {0}", e);
    }

    //Console.WriteLine("\n Press Enter to continue...");
    //Console.Read();
    return returned;
}


string coordinatesToAttack = " ";
string ipAddress = "127.0.0.1";
// test serialize

// </wf>

Car myObj = new Car();

String test1=JsonSerializeFunction(myObj);


Console.WriteLine(test1);
String test = Console.ReadLine()!;



Console.WriteLine("Donner l'addresse IP du serveur");
ipAddress = Console.ReadLine()!;
//Connect("192.168.43.8");
Connect(ipAddress);
do
{
    Console.WriteLine("où envoyer le missile?");
    coordinatesToAttack = Console.ReadLine()!;
    string hitOrNot = Connect("192.168.43.8", coordinatesToAttack);
    Console.WriteLine("message reçu {0}", hitOrNot);
    // locally updating the opponent map
    // waiting for the opponent to play
    // get his move (missile)
    Console.WriteLine("Waiting for opponent's move");
    string coordinatesAttacked = Connect("192.168.43.8");
    Console.WriteLine("message reçu {0}", coordinatesAttacked);
    // updating my map
    // telling oppponent whether they hit me or not
    Connect("192.168.43.8", "not hit"); // to process
} while (coordinatesToAttack.ToLower() != "stop");







