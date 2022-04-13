using System;
using Jeu.BatailleNavaleGame;
using Jeu.Menus;
using static System.Console;

namespace  Jeu
{
    /// <summary>
    /// classe correpondant au point d'entrée de l'application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// point d'entrée de l'application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Game myGame = new();
            myGame.Start();

            /*Fleet fleet1 = new Fleet();

            Boat b = new("Willy", "Orque", new string[] { "A1", "A2", "A3" });

            b.WriteInfo();*/

        }
    }
}