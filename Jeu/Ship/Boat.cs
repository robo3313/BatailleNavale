﻿using System.Text.Json.Serialization;

namespace Jeu
{
    /// <summary>
    /// classe Boat
    /// </summary>
    public class Boat
    {
        public string Name;
        public string Type;
        public Dictionary<Position, bool> Positions;
        public bool Alive = true;

        public Boat() {}

        static public string[] Types = new string[] { "Frigate", "Galleon", "Battleship" };

        /// <summary>
        /// constructeur de la classe Boat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="positions"></param>

        public Boat(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Boat(string name, string type, Position[] positions)
        {
            Name = name;
            Type = type;
            Positions = new ();
            Position newPosition;

            foreach (Position pos in positions)
            {
                Positions.Add(pos, true);
            }
        }

        public int Attack(Position coordinates)
        {
            foreach (KeyValuePair<Position, bool> pos in Positions)
            {
                if (pos.Key == coordinates)
                {
                    Positions[pos.Key] = false;
                    CheckDeath();
                    return Alive ? 1 : 2;
                }
            }
            return 0;
        }

        public void CheckDeath()
        {
            int i = 0;
            foreach (KeyValuePair<Position, bool> pos in Positions)
            {
                if (!pos.Value){
                    i++;
                }
            }
            if (i == Positions.Count())
            {
                Alive = false;
            }
        }

        // affiche name and type of boat
        public void WriteInfo()
        {
            Console.WriteLine("     Nom: {0}, Type: {1}, Statut: {2}", Name, Type, Alive);
            if (Positions == null)
            {
                return;
            }
            foreach(KeyValuePair<Position, bool> pair in Positions)
            {
                Console.WriteLine("     Pos: {0}{1}, Alive: {2}", pair.Key.Column, pair.Key.Row, pair.Value);
            }
        }
        public override string ToString()
        {
            string res = Name + " " + Type;
            foreach (KeyValuePair<Position, bool> pos in Positions)
            {
                res += " " + pos.Key.ToString();
            }
            return res;
        }

        public void checkType(string boatType)
        {
            if (Array.IndexOf(Types, boatType) < 0)
            {
                throw new Exception("Boat type " + boatType + " is not recognized");
            }
        }

    }
}