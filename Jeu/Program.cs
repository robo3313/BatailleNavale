/*using System;
using Jeu.BatailleNavaleGame;
using Jeu.Menus;
using static System.Console;*/

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
            /*Game myGame = new();
            myGame.Start();*/

            Fleet fleet1 = new Fleet();
            fleet1.AddBoat("Willy", "Orque", new string[] { "A1", "A2", "A3" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "D5", "D6", "D7" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "B9", "B10", "B11" });


        }
    }




}

