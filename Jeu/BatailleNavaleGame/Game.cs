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
        internal Engine engine = new();          
        /// <summary>
        /// méthode de démarrage du jeu Bataille Navale
        /// </summary>
        public void Start()
        {
            Title = "Bataille Navale - The Game !";
            RunMainMenu();
        }

        public Game()
        {

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
                    SelectBoatCoordinates();
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
            int firstLineGrid = CursorTop;
            grid.Display(firstLineGrid);

            ConsoleKey keyPressed;
            do
            {
                WriteLine("\nAppuie sur entrée pour choisir ton bateau");
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
            } while (keyPressed != ConsoleKey.Enter);

            //afficher la flotte
            grid.DisplayFleet(firstLineGrid);
        }

        /// <summary>
        /// récupère les coordonnées du curseur
        /// </summary>
        /// <returns></returns>
        public List<int> GetCursorPosition()
        {
            List<int> result = new();
            int top = CursorTop;
            int left = CursorLeft;
            
            result.Add(top);
            result.Add(left);

            return result;
        }

        public void SelectBoatCoordinates()
        {
            int nbLigneMenu = 4; //titre + 3 types bateau (à modifier plus tard si évolution)
            string[] arrayBoatCoordinates;

            //ajouter 5 bateaux et afficher la grille avec les bateaux
            for (int i = 0; i < 5; i++)
            {
                string strBoatName = "", strCoordinates = "";
                //positionner la flotte
                InitialGameMenu menuBoat = new("\nChoisis un bateau dans la liste", Boat.Types);
                menuBoat.Run();

                List<int> cursorBefore = GetCursorPosition();   //récupère la position avant traitement

                WriteLine("Donne un nom à ton bateau.");
                ForegroundColor = ConsoleColor.DarkCyan;
                do
                {
                    strBoatName = ReadLine();
                } while (strBoatName == "");
                
                ResetColor();

                WriteLine("Ecris les coordonnées du bateau comme ceci A1,A2");
                ForegroundColor = ConsoleColor.DarkCyan;
                strCoordinates = ReadLine();
                ResetColor();

                arrayBoatCoordinates = strCoordinates!.Split(',').ToArray();

                string boatType = menuBoat.Options[menuBoat.SelectedIndex];

                //WriteLine($"Tu vas positionner le bateau {strBoatName} de type {boatType} dans les cases {strCoordinates}");

                engine.AddBoat(strBoatName!, boatType, arrayBoatCoordinates);   //ajoute un bateau

                //derniere position
                List<int> cursorposition = GetCursorPosition(); //récupère la position après traitement

                for (int cur = cursorBefore[0] - nbLigneMenu; cur <= cursorposition[0]; cur++)
                {
                    SetCursorPosition(0, cur);
                    Write(new String(' ', WindowWidth));    //on vide les lignes pour réafficher le menu et la grille
                }

                SetCursorPosition(0, cursorBefore[0]);

                engine.DisplayGrid();
                Read();
            }
        }

        public void DisplayTimerMessage()
        {
            string str = "|";
            for (int i = 0; i < 50; i++)
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
