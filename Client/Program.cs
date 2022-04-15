using Networking;

Client client = new();
string str = null;
string res;

try
{
    client.Connect("192.168.1.128");

    while (str != "exit")
    {
        Console.WriteLine("Send message to Server :");
        str = Console.ReadLine();
        client.SendMessage(str);
        res = client.WaitResponse();
    }
    client.End();
} catch (Exception e)
{
    Console.WriteLine("Error : "+e.ToString());
}
