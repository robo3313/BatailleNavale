using Networking;

Client client = new();

try
{
    //Console.WriteLine("Enter the Server IP Address:");
    client.Connect("127.0.0.1");
    //Ask to build Fleet here
    client.SendFleet();
    client.WaitResponse();
    client.HandleResponse();
    client.Attack();

    while (client.WaitResponse())
    {
        client.HandleResponse();
        client.Attack();
    }
    //client.End();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
