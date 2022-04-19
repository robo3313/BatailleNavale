using System.Text.Json.Serialization;
﻿using static System.Console;

namespace Jeu
{
    /// <summary>
    /// Classe Boat
    /// </summary>
    public class Boat
    {
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public string Type;
        [JsonInclude]
        public Dictionary<Position, bool> Positions;
        [JsonInclude]
        public bool Alive = true;

        public static string[] Types = new string[] { "Frigate", "Galleon", "Battleship" };

        /// <summary>
        /// Constructeur par défaut de la classe Boat
        /// </summary>
        public Boat() {}

        /// <summary>
        /// Constructeur de la classe Boat
        /// </summary>
        /// <param name="name">Le nom du bateau</param>
        /// <param name="type">Le type de bateau (pas utilisé pour l'insant)</param>
        public Boat(string name, string type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Constructeur de la classe Boat
        /// </summary>
        /// <param name="name">Le nom du bateau</param>
        /// <param name="type">Le type de bateau (pas utilisé pour l'instant)</param>
        /// <param name="positions">Un tableau de position désignant la ou se trouve le bateau</param>
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

        /// <summary>
        /// Constructeur de la classe Boat
        /// </summary>
        /// <param name="b">Un objet de classe SerialBoat</param>
        public Boat(SerialBoat b)
        {
            Name = b.Name;
            Type = b.Type;
            Positions = new();
            foreach (KeyValuePair<string, bool> pos in b.Positions)
            {
                Positions.Add(Position.createFromString(pos.Key), pos.Value);
            }
        }

        /// <summary>
        /// Teste si un attaque aux coordonées de la Position touche le bateau
        /// </summary>
        /// <param name="coordinates">Position</param>
        /// <returns>0 si le bateau n'est pas touché, 1 si le bateau est touché, 2 si il est coulé</returns>
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

        /// <summary>
        /// Vérifie si le bateau est Coulé, si c'est le cas la propriété Alive est changée pour false
        /// </summary>
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

        /// <summary>
        /// Affiche les informations du bateau dans la console
        /// </summary>
        public void WriteInfo()
        {
            WriteLine("     Nom: {0}, Type: {1}, Statut: {2}", Name, Type, Alive);
            if (Positions == null)
            {
                return;
            }
            foreach(KeyValuePair<Position, bool> pair in Positions)
            {
                WriteLine("     Pos: {0}{1}, Alive: {2}", pair.Key.Column, pair.Key.Row, pair.Value);
            }
        }

        /// <summary>
        /// Retourne l'objet sous forme de string qui peut être affichée
        /// </summary>
        /// <returns>string représentant l'objet</returns>
        public override string ToString()
        {
            string res = Name + " " + Type;
            foreach (KeyValuePair<Position, bool> pos in Positions)
            {
                res += " " + pos.Key.ToString();
            }
            return res;
        }

        /// <summary>
        /// Vérifie si le type de bateau est bien connu. Pas implémenté pour l'instant.
        /// </summary>
        /// <param name="boatType"></param>
        /// <exception cref="Exception"></exception>
        public void checkType(string boatType)
        {
            if (Array.IndexOf(Types, boatType) < 0)
            {
                throw new Exception("Boat type " + boatType + " is not recognized");
            }
        }

    }
}