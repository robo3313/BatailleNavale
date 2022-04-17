using System.Text.Json;
using System.Text.Json.Serialization;
﻿using static System.Console;

namespace Jeu
{
    /// <summary>
    /// classe correspondant à la flotte
    /// </summary>
    public class Fleet
    {
        /// <summary>
        /// propriété UserFleet qui est une liste d'objet Boat
        /// </summary>
        [JsonInclude]
        public List<Boat> UserFleet { get; set; }
        public List<Position> BoatPositions { get; set; }

        public Fleet()
        {
            UserFleet = new();
            BoatPositions = new();
        }

        /// <summary>
        /// constructeur de la classe Fleet
        /// </summary>
        /// <param name="listboat"></param>
        public Fleet(List<Boat> listboat)
        {
            UserFleet = listboat;
            BoatPositions = new();
            foreach (Boat b in listboat)
            {
                foreach (KeyValuePair<Position, bool> pos in b.Positions)
                {
                    BoatPositions.Add(pos.Key);
                }
            }
        }

        public Fleet(SerialFleet fl)
        {
            UserFleet = new();
            foreach (SerialBoat b in fl.UserFleet)
            {
                UserFleet.Add(new Boat(b));
            }
            BoatPositions = fl.BoatPositions;
        }

        public void AddBoat(string name, string type, Position[] coordinates)
        {
            try
            { 
                Boat b = new(name, type, coordinates);
                UserFleet.Add(b);
                foreach (Position pos in coordinates)
                {
                    BoatPositions.Add(pos);
                }
            }
            catch (Exception e)
            {
                WriteLine("Erreur lors de la création du bateau : {0}", e.Message);
            }
        }

        public Boat? Attack(Position coordinates)
        {
            int tmp;
            foreach (Boat boat in UserFleet)
            {
                tmp = boat.Attack(coordinates);
                if (tmp > 0)
                {
                    return boat;
                }
            }
            return null;
        }

        public int CountAliveBoats()
        {
            int res = 0;
            foreach (Boat b in UserFleet)
            {
                res += b.Alive ? 1 : 0;
            }
            return res;
        }

        public void DisplayBoatPositions()
        {
            Write("Boat positions : ");
            foreach (Position pos in BoatPositions)
            {
                Write(pos+ " ");
            }
            WriteLine();
        }

        public void Display()
        {
            foreach (Boat b in UserFleet)
            {
                b.WriteInfo();
            }
        }

    }
}
