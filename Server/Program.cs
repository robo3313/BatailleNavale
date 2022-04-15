using Network;

Server server = new();
string str;
string res;


try
{
    while (true)
    {
        server.WaitConnection();
        Console.WriteLine("New Client connection !");
        while (true)
        {
            res = server.WaitMessage();
            if (res == "EXIT")
            {
                break;
            }
            Console.WriteLine("Send message to Client :");
            str = Console.ReadLine();
            server.sendMessage(str);

        }
        Console.WriteLine("Client left...");
        server.End();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}