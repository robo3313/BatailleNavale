using Network;
using Jeu;

Server server = new();

while (true)
{
    try
    {
        //Waiting for a player
        server.WaitConnection();
        server.WaitResponse();
        server.HandleResponse();
        server.SendFleet();
        while (server.WaitResponse())
        {
            server.HandleResponse();
            server.Attack();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    //server.End();
}