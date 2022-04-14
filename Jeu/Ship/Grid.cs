﻿namespace Jeu
{
    public class Grid
    {
        Dictionary<char, int> Case = new Dictionary<char, int>()
        {
            {'A',0}, {'B',1}, {'C',2},{'D',3},{'E',4},{'F',5},{'G',6},{'H',7},{'I',8},{'J',9},
        };

        int[,] G = new int[10, 10] { { 0, 0 , 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        enum CaseType
        {
            Vide = 0,
            Impact = 1,
            Bateau = 2,
            Touche = 3,
            Coule = 4
        }
        public void Display()
        {
            Console.WriteLine(" A B C D E F G H I J");

            for (int i = 0; i < G.GetLength(0); i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < G.GetLength(1); j++)
                {
                    Console.Write(AddResult(G[i, j]));
                }
                Console.WriteLine();
            }
        }
        public void AddBoat(Boat b)
        {
            foreach (KeyValuePair<Position, bool> pair in b.Positions)
            {
                Console.WriteLine("Ma position humaine est : {0}  {1}", pair.Key, pair.Value);

                int[] ComputerPos = GetComputerCoordinate(pair.Key.Column, pair.Key.Row);
                G[ComputerPos[0], ComputerPos[1]] = 2;

                Console.WriteLine("Ma position ordinateur est : {0} {1}", ComputerPos[0], ComputerPos[1]);
            }
        }
        public void AddImpact(Position p)
        {
            Console.WriteLine("Il y a eu un impact : {0} {1}", p.Column, p.Row);

            int[] ComputerPos = GetComputerCoordinate(p.Column, p.Row);
            G[ComputerPos[0], ComputerPos[1]] = 1;

            Console.WriteLine("Il y a eu un impact : {0} {1}", ComputerPos[0], ComputerPos[1]);
        }
        public string AddResult(int param)
        {
            switch(param)
            {
                case 0:
                    return ("  ");

                case 1:
                    return ("X ");

                case 2:
                    return ("B ");

                case 3:
                    return ("T ");

                case 4:
                    return ("C ");
            }
            return " ";

         }

        public int[] GetComputerCoordinate(char column, int row)  // ex : col = D, row = 7
        {
            int[] res = new int[2];
            res[0] = row - 1;
            Case.TryGetValue(column, out res[1]);
            return res;
        }

        
    }
}
