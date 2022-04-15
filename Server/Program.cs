using Network;

Server server = new();

try
{
    server.WaitConnection();
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}