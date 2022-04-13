using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeu.Menus;
using static System.Console;

namespace Jeu.BatailleNavaleGame
{
    /// <summary>
    /// classe Game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// méthode de démarrage du jeu Bataille Navale
        /// </summary>
        public void Start()
        {
            Title = "Bataille Navale - The Game !";
            RunMainMenu();
        }

        /// <summary>
        /// lance le menu principal du jeu
        /// </summary>
        private void RunMainMenu()
        {
            string logo = @"


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
            string prompt = "Bienvenu dans le jeu Bataille Navale. Que veux tu faire ?\n(Utilise les flèches pour naviguer dans le menu puis la touche entrée pour valider ton choix).\n";
            string[] options = { "Jouer", "A propos", "Quitter" };
            InitialGameMenu mainMenu = new(prompt, logo, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        /// <summary>
        /// méthode pour quitter le jeu à partir du menu principal
        /// </summary>
        private void ExitGame()
        {
            WriteLine("\nTape n'importe quelle touche pour sortir...");
            ReadKey(true);
            Environment.Exit(0);
        }

        /// <summary>
        /// méthode pour afficher les informations relatives au jeu
        /// </summary>
        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("Ce jeu a été créé par la team La Manu.");
            WriteLine("C'est un jeu très amusant. Ce n'est que la première version !");
            WriteLine("Des nouveautés sont à venir...\n");
            WriteLine("Tape n'importe quelle touche pour revenir au menu principal.");
            ReadKey(true);
            RunMainMenu();
        }

        /// <summary>
        /// méthode pour lancer le premier choix
        /// </summary>
        private void RunFirstChoice()
        {
            WriteLine("On va jouer maintenant...");
            ExitGame();
        }
    }
}
