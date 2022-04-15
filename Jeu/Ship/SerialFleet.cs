using System.Text.Json;
using System.Text.Json.Serialization;
﻿using static System.Console;

namespace Jeu
{
    public class SerialFleet
    {
        [JsonInclude]
        public List<SerialBoat> UserFleet { get; set; }
        [JsonInclude]
        public List<Position> BoatPositions { get; set; }

        public SerialFleet() { }

        public SerialFleet(Fleet fl)
        {
            UserFleet = new();
            foreach (Boat b in fl.UserFleet)
            {
                UserFleet.Add(new SerialBoat(b));
            }
            BoatPositions = fl.BoatPositions;
        }
    }
}
