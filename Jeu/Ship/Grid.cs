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
        public void Display()
        {
            int decalage = 20;  //décalage affichage grille

            int currentLineCursor = Console.CursorLeft;
            Console.SetCursorPosition(0 + decalage, Console.CursorTop);
        
            Console.WriteLine(" ABCDEFGHIJ");

            for (int i = 0; i<G.GetLength(0); i++)
            {
                if (i == 9) decalage -= 1;  //aligne les coordonnées verticales

                Console.SetCursorPosition(0 + decalage, Console.CursorTop);
                Console.Write(i+1);
                for (int j = 0; j < G.GetLength(1); j++)
                {
                    Console.Write(G[i,j]);
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
        /*public void AddImpact(Position i)
        {
       
            int[] ComputerPos =  
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
