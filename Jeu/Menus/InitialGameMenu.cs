using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Jeu.Menus
{
    /// <summary>
    /// classe InitalGameMenu
    /// </summary>
    public class InitialGameMenu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private string Logo;

        /// <summary>
        /// constructeur de la classe InitailGameMenu
        /// </summary>
        /// <param name="prompt">le texte d'accueil</param>
        /// <param name="logo">le logo</param>
        /// <param name="options">le tableau contenant les choix</param>
        public InitialGameMenu(string prompt, string logo, string[] options)
        {
            Prompt = prompt;
            Logo = logo;
            Options = options;
            SelectedIndex = 0;
        }
        /// <summary>
        /// affiche les options du menu principal du jeu
        /// </summary>
        private void DisplayOptions()
        {
            //afficher le logo du jeu
            WriteLine(Logo, ForegroundColor = ConsoleColor.Green);
            ResetColor();
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

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        /// <summary>
        /// lancement du jeu
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

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
