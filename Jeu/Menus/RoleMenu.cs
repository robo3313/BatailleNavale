using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Jeu.Menus
{
    /// <summary>
    /// classe pour le choix du statut du joueur (héberge la partie ou invité)
    /// </summary>
    public class RoleMenu : InitialGameMenu
    {
        /// <summary>
        /// constructeur de la classe RoleMenu
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="options"></param>
        /// <param name="logo"></param>
        public RoleMenu(string prompt, string[] options, string logo = "") : base(prompt, options, logo)
        {
            
        }

        /// <summary>
        /// méthode d'affichage du menu pour le choix du rôle
        /// </summary>
        protected override void DisplayOptions()
        {
            //afficher le logo du jeu
            WriteLine(Logo, ForegroundColor = ConsoleColor.Green);
            ResetColor();
            //affiche et formate les instructions du menu principal au début de l'application
            WriteLine(Prompt);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                string suffix = "";

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    if ((prefix == "*") && (i == 0))
                    {
                        suffix = Constants._STRHOST;
                    }
                    else
                    {
                        suffix = Constants._STRPGUEST;
                    }
                    
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >> {suffix}");
            }
            ResetColor();
        }
    }
}
