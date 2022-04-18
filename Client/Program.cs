using Networking;

Client client = new();
bool connected = false;

while (connected == false)
{
    try
    {
        Console.WriteLine("Enter the Server IP Address:");
        client.Connect(Console.ReadLine());
        connected = true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

try
{
    client.setupFleet();
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
