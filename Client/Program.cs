using Networking;

Client client = new();

try
{
    client.Connect("192.168.1.128");
    Console.WriteLine("Envoyer un message au serveur :");
    string msg = Console.ReadLine();
    client.SendMessage(msg);
    client.End();
} catch (Exception e)
{
    Console.WriteLine("Error : "+e.ToString());
}
