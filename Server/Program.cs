using Network;
using Jeu;

Server server = new();
Engine engine = new();
NavalMessage nm;
string str;
string res;

try
{
    while (true)
    {
        Console.Clear();
        engine.DisplayGrid();
        server.WaitConnection();
        Console.WriteLine("New Client connection !");
        while (true)
        {
            nm = server.WaitMessage();
            switch (nm.Type)
            {
                case 2:
                    engine.setFleet(new Fleet(nm.Fleet));
                    break;
                default:
                    break;
            }
            engine.DisplayGrid();
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