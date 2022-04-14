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
            string prompt = "Bienvenu dans le jeu Bataille Navale. Que veux tu faire ?\n(Utilise les flèches pour naviguer dans le menu puis la touche entrée pour valider ton choix).\n";
            string[] options = { "Jouer", "A propos", "Quitter" };
            InitialGameMenu mainMenu = new(prompt, options, Constants._LOGO);
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
            string prompt = "Choisis le role que tu souhaites avoir durant la partie.\n(Utilise les flèches pour naviguer dans le menu puis la touche entrée pour valider ton choix).\n";
            string[] options = { "Hébergeur", "Invité" };
            RoleMenu roleMenu = new(prompt, options,Constants._LOGO);
            int selectedIndex = roleMenu.Run();

            Grid grid = new Grid();

            switch (selectedIndex)
            {
                case 0:
                    DisplayGridAndFleet(grid, selectedIndex);
                    break;
                case 1:
                    DisplayGridAndFleet(grid, selectedIndex);
                    break;
            }            
            ExitGame();
        }

        /// <summary>
        /// méthode qui affiche la grille et la flotte
        /// </summary>
        /// <param name="grid">objet grille</param>
        /// <param name="selectedIndex">l'index dans le tableau</param>
        /// <param name="displayOthers">permet d'afficher des distinctions entre les grilles</param>
        public void DisplayGridAndFleet(Grid grid, int selectedIndex, bool displayOthers = false)
        {
            Clear();
            WriteLine(Constants._LOGO, ForegroundColor = ConsoleColor.Green);
            ResetColor();

            WriteLine("Veuillez patientez pendant le chargement de la grille.");

            DisplayTimerMessage();

            //Afficher la grille du joueur
            int firstLineGrid;
            grid.Display(out firstLineGrid);

            //afficher la flotte
            grid.DisplayFleet(firstLineGrid);

            //positionner la flotte
            InitialGameMenu menuBoat = new("Choisis un bateau dans la liste", Boat.Types);
            menuBoat.Run(false);
        }

        public void DisplayTimerMessage()
        {
            string str = "|";
            for (int i = 0; i < 100; i++)
            {
                Write(str);
                Thread.Sleep(20);
            }
            DeleteLineContent();
        }

        //supprime le contenu de la ligne dans la console
        public void DeleteLineContent()
        {
            int currentLineCursor = CursorTop;
            SetCursorPosition(0, CursorTop);
            Write(new string(' ', WindowWidth));
            SetCursorPosition(0, currentLineCursor - 1);
            Write(new string(' ', WindowWidth));
            SetCursorPosition(0, currentLineCursor);
        }
    }
}
