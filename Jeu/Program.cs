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

            /*Fleet f = new();
            Boat b = new("toto", "navire", new string[] { "G5", "G6", "G7"});
            b.WriteInfo();


            Grid g = new();
            g.AddBoat(b);
            g.Display();
            g.AddImpact(i);*/
        }
    }



}

