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
        }
    }

}

