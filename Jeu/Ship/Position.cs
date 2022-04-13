namespace Jeu
{
    class Position
    {
        char Column { get; set; }
        int Row { get; set; }

        public Position(char column, int number)
        {
            Column = column;
            Row = number;
        }

        // Traitement des coordonnées & cas d'erreurs
        public static Position createFromString(string columnRow)
        {
            Console.WriteLine("columnRow = {0}", columnRow);
            char letter = Char.ToUpper(columnRow[0]);
            int number;
            if (Int32.TryParse(columnRow[1].ToString(), out number) == false)
            {

                throw new Exception("Impossible de placer un bateau en " + columnRow);
            }

            Int32.TryParse(columnRow[1].ToString(), out number);


            if (letter < 'A' && letter > 'J' && number <= 0 && number > 9 || (columnRow.Length == 3 && columnRow[2] != 0))

            {
                throw new Exception("Impossible de placer un bateau en " + columnRow);
            }
            else if (columnRow[1] == 1 && columnRow[2] == '0')
            {
                int numbers = 10;
                Position res = new Position(columnRow[0], numbers);
                return res;
            }
            else
            {
                Position res = new Position(columnRow[0], number);
                return res;
            }
        }

        public override string ToString()
        {
            return Column.ToString() + Row.ToString();
        }

    }
}
 