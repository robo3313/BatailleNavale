using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Client;
public class Serial
{
    public string JsonSerializeFunction(Car a, string ip= "192.168.43.8")
    {
        string jsonString = JsonSerializer.Serialize(a);

        //String string = Connect(ip, jsonString);

        return jsonString;
    }

}

public class Car
{
    string color = "red";

}