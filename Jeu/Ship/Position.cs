namespace Jeu
{
    class Position
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public Position(char column, int number)
        {
            Column = column;
            Row = number;
        }

        // Traitement des coordonnées & cas d'erreurs
        public static Position createFromString(string columnRow)
        {
            int number;
            string str = columnRow.Substring(1);
            if (!Int32.TryParse(str, out number))
            {
                throw new Exception("Impossible d'utiliser la coordonnée "+ str);
            }
            return new Position(columnRow[0], number);
        }

        public static Position[] createFromStringArray(string[] coordinates)
        {
            Position[] result = new Position[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
            {
                result[i] = createFromString(coordinates[i]);
            }
            return result;
        }

        public override string ToString()
        {
            return Column.ToString() + Row.ToString();
        }

    }
}
 