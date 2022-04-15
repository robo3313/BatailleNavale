using Network;

Server server = new();
string str;
string res;


try
{
    server.WaitConnection();
    Console.WriteLine("New Client connection !");
    while (true)
    {
        res = server.WaitMessage();
        Console.WriteLine("Send message to Client :");
        str = Console.ReadLine();
        server.sendMessage(str);

    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}