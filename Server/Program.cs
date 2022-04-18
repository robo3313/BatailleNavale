using Network;
using Jeu;

Server server = new();
int gameState = 0;

while (true)
{
    try
    {
        server.WaitConnection();
        server.setupFleet();
        //Waiting for a player
        server.WaitResponse();
        server.HandleResponse();
        server.SendFleet();
        while (server.WaitResponse() && gameState != 2)
        {
            server.HandleResponse();
            server.Attack();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}