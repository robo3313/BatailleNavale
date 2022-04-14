using System;
using Jeu.BatailleNavaleGame;
using Jeu.Menus;
using static System.Console;

namespace  Jeu
{
    /// <summary>
    /// classe statique pour les constantes
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// constante pour le logo du jeu
        /// </summary>
        public const string _LOGO = @"


 ▄▄▄▄    ▄▄▄     ▄▄▄█████▓ ▄▄▄       ██▓ ██▓     ██▓    ▓█████     ███▄    █  ▄▄▄    ██▒   █▓ ▄▄▄       ██▓    ▓█████       ▄▄▄█████▓ ██░ ██ ▓█████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▐██▌ 
▓█████▄ ▒████▄   ▓  ██▒ ▓▒▒████▄    ▓██▒▓██▒    ▓██▒    ▓█   ▀     ██ ▀█   █ ▒████▄ ▓██░   █▒▒████▄    ▓██▒    ▓█   ▀       ▓  ██▒ ▓▒▓██░ ██▒▓█   ▀     ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀     ▐██▌ 
▒██▒ ▄██▒██  ▀█▄ ▒ ▓██░ ▒░▒██  ▀█▄  ▒██▒▒██░    ▒██░    ▒███      ▓██  ▀█ ██▒▒██  ▀█▄▓██  █▒░▒██  ▀█▄  ▒██░    ▒███         ▒ ▓██░ ▒░▒██▀▀██░▒███      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███       ▐██▌ 
▒██░█▀  ░██▄▄▄▄██░ ▓██▓ ░ ░██▄▄▄▄██ ░██░▒██░    ▒██░    ▒▓█  ▄    ▓██▒  ▐▌██▒░██▄▄▄▄██▒██ █░░░██▄▄▄▄██ ▒██░    ▒▓█  ▄       ░ ▓██▓ ░ ░▓█ ░██ ▒▓█  ▄    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄     ▓██▒ 
░▓█  ▀█▓ ▓█   ▓██▒ ▒██▒ ░  ▓█   ▓██▒░██░░██████▒░██████▒░▒████▒   ▒██░   ▓██░ ▓█   ▓██▒▒▀█░   ▓█   ▓██▒░██████▒░▒████▒        ▒██▒ ░ ░▓█▒░██▓░▒████▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒    ▒▄▄  
░▒▓███▀▒ ▒▒   ▓▒█░ ▒ ░░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░ ▒░▓  ░░░ ▒░ ░   ░ ▒░   ▒ ▒  ▒▒   ▓▒█░░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░░ ▒░ ░        ▒ ░░    ▒ ░░▒░▒░░ ▒░ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░    ░▀▀▒ 
▒░▒   ░   ▒   ▒▒ ░   ░      ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░░ ░ ▒  ░ ░ ░  ░   ░ ░░   ░ ▒░  ▒   ▒▒ ░░ ░░    ▒   ▒▒ ░░ ░ ▒  ░ ░ ░  ░          ░     ▒ ░▒░ ░ ░ ░  ░     ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░    ░  ░ 
 ░    ░   ░   ▒    ░        ░   ▒    ▒ ░  ░ ░     ░ ░      ░         ░   ░ ░   ░   ▒     ░░    ░   ▒     ░ ░      ░           ░       ░  ░░ ░   ░      ░ ░   ░   ░   ▒   ░      ░      ░          ░ 
 ░            ░  ░              ░  ░ ░      ░  ░    ░  ░   ░  ░            ░       ░  ░   ░        ░  ░    ░  ░   ░  ░                ░  ░  ░   ░  ░         ░       ░  ░       ░      ░  ░    ░    
      ░                                                                                  ░                                                                                                          
";
        public const string _STRHOST = "en choisissant cette option tu décides d'héberger la partie en attendant qu'un autre joueur te rejoigne";
        public const string _STRPGUEST = "en choisissant cette option tu décides de rejoindre une partie hébergée par un autre joueur";
    }
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

            /*
            Fleet fleet1 = new Fleet();
            fleet1.AddBoat("Willy", "Orque", new string[] { "A1", "A2", "A3" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "D5", "D6", "D7" });

            fleet1.AddBoat("Willy", "Orque", new string[] { "B9", "B10", "B11" });
            */

            /*Fleet f = new();
            Boat b = new("toto", "navire", new string[] { "G5", "G6", "G7"});
            b.WriteInfo();



            Grid g = new();
            g.AddBoat(b);
            g.Display();
            g.AddImpact(i);*/
            /*Fleet f = new();
            Boat b1 = new("Gary", "Galleon");
            Boat b2 = new("William", "Warship");
            b1.WriteInfo();
 