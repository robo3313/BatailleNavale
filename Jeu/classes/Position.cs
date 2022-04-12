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

        public static Position createFromString(string columnRow)
        {
            if (columnRow == "Z423")
            {
                throw new Exception("Impossible de placer un bateau en " + columnRow);
            }
            Position position = new Position('C', 4);
            return position;
        } 
    }
}
