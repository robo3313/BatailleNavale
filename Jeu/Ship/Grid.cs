﻿using static System.Console;

namespace Jeu
{
    public class Grid
    {
        Dictionary<char, int> Case = new Dictionary<char, int>()
        {
            {'A',0}, {'B',1}, {'C',2},{'D',3},{'E',4},{'F',5},{'G',6},{'H',7},{'I',8},{'J',9},
        };

        int[,] G = new int[10, 10] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        
  //      for (int i = 0; i<length; i++)
		//{
  //          int[,] G = new int { 0, 0, 0, 0, 0, 0, 0};
		//}
        enum CaseType
        {
            Vide = 0,
            Impact = 1,
            Bateau = 2,
            Touche = 3,
            Coule = 4
        }

        /// <summary>
        /// méthode qui affiche la grille
        /// </summary>
        /// <param name="firstLineGrid">paramètre de sortie pour la première ligne de la grille</param>
        public void Display(out int firstLineGrid)
        {
            int decalage = 20;  //décalage affichage grille
            firstLineGrid = CursorTop;

            int currentLineCursor = CursorLeft;
            SetCursorPosition(0 + decalage, CursorTop);
        
            WriteLine(" ABCDEFGHIJ");

            for (int i = 0; i<G.GetLength(0); i++)
            {
                if (i == 9) decalage -= 1;  //aligne les coordonnées verticales

                SetCursorPosition(0 + decalage, CursorTop);
                Write(i+1);
                for (int j = 0; j < G.GetLength(1); j++)
                {
                    Write(G[i,j]);
                }
                WriteLine();
            }
        }

        /// <summary>
        /// méthode qui affiche la flotte à côté de la grille
        /// </summary>
        /// <param name="firstLineGrid">correspond à la première ligne de la grille</param>
        public void DisplayFleet(int firstLineGrid)
        {
            int decalage = 50;  //décalage affichage flotte
            SetCursorPosition(0 + decalage, firstLineGrid);
            WriteLine("Place ta flotte sur la grille pour commencer.");
            SetCursorPosition(0 + decalage, firstLineGrid + 1); //replace le curseur avec le décalage 
        }
        public void AddBoat(Boat b)
        {
            foreach (KeyValuePair<Position, bool> pair in b.Positions)
            {
                WriteLine("Ma position humaine est : {0}  {1}", pair.Key, pair.Value);

                int[] ComputerPos = GetComputerCoordinate(pair.Key.Column, pair.Key.Row);
                G[ComputerPos[0], ComputerPos[1]] = 2;

                WriteLine("Ma position ordinateur est : {0} {1}", ComputerPos[0], ComputerPos[1]);
            } 
        }
        /*public void AddImpact()
        {
            int[] ComputerPos = GetComputerCoordinate(column.column, number.row);
            G[ComputerPos[0], ComputerPos[1]] = 1;

            Console.WriteLine("Ma position ordinateur est : {0} {1}", ComputerPos[0], ComputerPos[1]);
        }*/
          
        public int[] GetComputerCoordinate(char column, int row)  // ex : col = D, row = 7
        {
            int[] res = new int[2];
            res[0] = row - 1;
            Case.TryGetValue(column, out res[1]);
            return res;
        }
    }
}
