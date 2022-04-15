using Networking;
using Jeu;
using System.Text.Json;

Client client = new();
Engine engine = new();
string str = null;
string res = null;

NavalMessage nm = NavalMessage.CreateFromFleet(engine.Fleet1);

try
{
    Console.WriteLine("Enter the Server IP Address:");
    str = Console.ReadLine();
    if (str == "")
    {
        str = "192.168.1.128";
    }
    client.Connect(str);

    Console.WriteLine("Placez un bateau");
    string input = Console.ReadLine();
    string[] tmp = input.Split(" ");

    engine.AddBoat(tmp[0], tmp[1], tmp[2].Split(","));


    while (nm.Type != 0)
    {
        Console.WriteLine("Send message to Server :");
        Console.ReadLine();
        nm = NavalMessage.CreateFromFleet(engine.Fleet1);
        client.SendMessage(nm);
        res = client.WaitResponse();
    }
    client.End();
} catch (Exception e)
{
    Console.WriteLine("Error : "+e.ToString());
}
