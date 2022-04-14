namespace Jeu
{
    public class Position : IEquatable<Position>
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
            char letter = Char.ToUpper(columnRow[0]);
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

        static public bool operator ==(Position first, Position second)
        {
            return first.Column == second.Column && first.Row == second.Row;
        }

        static public bool operator !=(Position first, Position second)
        {
            return first.Column != second.Column || first.Row != second.Row;
        }

        public bool Equals(Position p)
        {

            return Column != p.Column || Row != p.Row;
        }


    }
}
 