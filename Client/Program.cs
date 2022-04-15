using Networking;
using Jeu;
using System.Text.Json;

Client client = new();
string str = null;
string res = null;

Fleet fleet1 = new();

fleet1.AddBoat("Liquid", "US", Position.createFromStringArray(new string[] { "D1", "D2", "D3" }));

NavalMessage nm = NavalMessage.CreateFromFleet(fleet1);

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
        Console.ReadLine();
        if (str == "exit")
        {
            break;
        }
        client.SendMessage(nm);
        res = client.WaitResponse();
    }
    client.End();
} catch (Exception e)
{
    Console.WriteLine("Error : "+e.ToString());
}
