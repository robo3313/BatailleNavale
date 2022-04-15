using System.Text.Json.Serialization;
﻿using static System.Console;

namespace Jeu
{
    public class SerialBoat
    {
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public string Type;
        [JsonInclude]
        public Dictionary<string, bool> Positions;
        [JsonInclude]
        public bool Alive = true;

        public SerialBoat() {}

        public static string[] Types = new string[] { "Frigate", "Galleon", "Battleship" };

        public SerialBoat(Boat b)
        {
            Name = b.Name;
            Type = b.Type;
            Positions = new();
            foreach (KeyValuePair<Position, bool> pos in b.Positions)
            {
                Positions.Add(pos.Key.ToString(), pos.Value);
            }
        }
    }
}