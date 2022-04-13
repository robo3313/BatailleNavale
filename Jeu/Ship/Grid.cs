namespace Jeu
{
    class Grid
    {
        Dictionary<char, int> Case = new Dictionary<char, int>()
        {
            {'A',0}, {'B',1}, {'C',2},{'D',3},{'E',4},{'F',5},{'G',6},{'H',7},{'I',8},{'J',9},
        };

        bool[,] G = new bool[10, 10];

        public void Display()
        {
           for (int i = 0; i<G.GetLength(0); i++)
            {

                for (int j = 0; j < G.GetLength(1); j++)
                {
                    Console.WriteLine("Affiche de la case : [{0},{1}]", i, j);
                }
            }
        }
        public int[] GetComputerCoordinate(char column, int row)  // ex : col = D, row = 7
        {
            int[] res = new int[2];

            foreach (KeyValuePair<char, int> pair in Case)
            {
                Console.WriteLine("Ma position est : {0}  {1}", pair.Key, pair.Value);
            }
            res[1] = row - 1;
            Case.TryGetValue(column, out res[0]);
            return res;
        }
    }
}
