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
        /// <summary>
        /// Ajoute les boats à la flotte UserFleet
        /// </summary>
        /// <param name="fl"></param>
        public Fleet(SerialFleet fl)
        {
            UserFleet = new();
            foreach (SerialBoat b in fl.UserFleet)
            {
                UserFleet.Add(new Boat(b));
            }
            BoatPositions = fl.BoatPositions;
        }
        /// <summary>
        /// Ne reourne rien, lit le nom, type et coordonnées d'un Boat, l'ajoute à la flotte et met à jour le tableau de positions
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="coordinates"></param>
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
        /// <summary>
        /// Retourne le boat si la position lise correspond à un boat de la flotte. Retourne Null sinon
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>Boat</returns>
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
        /// <summary>
        /// Retourne le nombre des Boats encore en vie
        /// </summary>
        /// <returns></returns>
        public int CountAliveBoats()
        {
            int res = 0;
            foreach (Boat b in UserFleet)
            {
                res += b.Alive ? 1 : 0;
            }
            return res;
        }
        /// <summary>
        /// Affiche toutes les positions des boats
        /// </summary>
        public void DisplayBoatPositions()
        {
            Write("Boat positions : ");
            foreach (Position pos in BoatPositions)
            {
                Write(pos+ " ");
            }
            WriteLine();
        }
        /// <summary>
        /// Affiche les positions et status (en vie ou pas) de tous les Boats
        /// </summary>
        public void Display()
        {
            foreach (Boat b in UserFleet)
            {
                b.WriteInfo();
            }
        }

    }
}
