using Networking;

Client client = new();
string str = null;
string res = null;

try
{
    Console.WriteLine("Enter the Server IP Address:");
    str = Console.ReadLine();
    if (str == "")
    {
        str = "192.168.1.128";
    }
    client.Connect(str);

    while (res != "KO")
    {
        Console.WriteLine("Send message to Server :");
        str = Console.ReadLine();
        if (str == "exit")
        {
            break;
        }
        client.SendMessage(str);
        res = client.WaitResponse();
    }
    client.End();
} catch (Exception e)
{
    Console.WriteLine("Error : "+e.ToString());
}
