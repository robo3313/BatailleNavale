using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Jeu.BatailleNavaleGame;

namespace Jeu.Menus
{
    /// <summary>
    /// classe InitalGameMenu
    /// </summary>
    public class InitialGameMenu
    {
        public int SelectedIndex { get; set; }
        public string[] Options { get; set; }
        public string Prompt { get; set; }
        public string Logo { get; set; }

        /// <summary>
        /// constructeur de la classe InitailGameMenu
        /// </summary>
        /// <param name="prompt">le texte d'accueil</param>
        /// <param name="logo">le logo</param>
        /// <param name="options">le tableau contenant les choix</param>
        public InitialGameMenu(string prompt, string[] options, string logo = "")
        {
            Prompt = prompt;
            Logo = logo;
            Options = options;
            SelectedIndex = 0;
        }

        /// <summary>
        /// affiche les options du menu principal du jeu
        /// </summary>
        /// <param name="decalage">indice de décalage du curseur pour l'affichage</param>
        protected virtual void DisplayOptions(int decalage = 0)
        {
            //afficher le logo du jeu
            if(decalage==0)
            {
                WriteLine(Constants._LOGO, ForegroundColor = ConsoleColor.Green);
                ResetColor();
            }

            //affiche et formate les instructions du menu principal au début de l'application
            WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string  currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                SetCursorPosition(decalage, CursorTop);

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        /// <summary>
        /// lancement du jeu
        /// </summary>
        /// <param name="initial">indique s'il s'agit du menu initial ou en cours de jeu</param>
        public int Run(bool initial = true)
        {
            int decalage = 0;
            ConsoleKey keyPressed;
            do
            {
                Clear();
                //if (!initial)
                //{
                //    WriteLine(Constants._LOGO,ForegroundColor = ConsoleColor.Green);
                //}
                ResetColor();
                
                //if (!initial) decalage = 50;
                
                DisplayOptions(decalage);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //mettre à jour l'index selon les touches bas et haut
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                        SelectedIndex = Options.Length - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                        SelectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;

        }
    }
}
