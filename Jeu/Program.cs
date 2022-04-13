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
        }
    }

}

