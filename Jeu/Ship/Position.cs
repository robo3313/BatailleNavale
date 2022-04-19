using System.Text.Json.Serialization;

namespace Jeu
{
    public class Position : IEquatable<Position>
    {
        [JsonInclude]
        public char Column { get; set; }
        [JsonInclude]
        public int Row { get; set; }

        public Position() {}
        /// <summary>
        /// Méthode pour définir les positions dans la grille
        /// </summary>
        /// <param name="column"></param>
        /// <param name="number"></param>
        public Position(char column, int number)
        {
            Column = column;
            Row = number;
        }

        /// <summary>
        /// Méthode qui retourne un booléen
        /// </summary>
        /// <param name="newPos"></param>
        /// <returns></returns>
        public bool isNextTo(Position newPos)
        {
            if (newPos.Column != Column && newPos.Row != Row)
            {
                return false;
            }
            int colDiff = Math.Abs(newPos.Column - Column);
            int rowDiff = Math.Abs(newPos.Row - Row);
            if ((colDiff == 1 && rowDiff == 0) || (colDiff == 0 && rowDiff == 1))
                return true;
            return false;
        }
        /// <summary>
        /// Méthode de traitement des coordonnées et cas d'erreurs
        /// </summary>
        /// <param name="columnRow"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception> 
        public static Position createFromString(string columnRow)
        {
            char letter = Char.ToUpper(columnRow[0]);
            int number;
            string str = columnRow.Substring(1);
            if (!Int32.TryParse(str, out number))
            {
                throw new ErrorException("Impossible d'utiliser la coordonnée "+ str);
            }
            return new Position(columnRow[0], number);
        }

        /// <summary>
        /// Méthode qui crée un tableau des positions de la grille
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public static Position[] createFromStringArray(string[] coordinates)
        {
            Position[] result = new Position[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
            {
                result[i] = createFromString(coordinates[i]);
            }
            return result;
        }

        /// <summary>
        /// Méthode qui retourne une chaine de caractère
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Column.ToString() + Row.ToString();
        }

        /// <summary>
        /// Méthode qui retourne un booléen 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static public bool operator ==(Position first, Position second)
        {
            if (first is null || second is null)
            {
                return false;
            }
            return first.Column == second.Column && first.Row == second.Row;
        }
        /// <summary>
        /// Méthode qui retourne un booléen  
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static public bool operator !=(Position first, Position second)
        {
            if (first is null || second is null)
            {
                return false;
            }
            return first.Column != second.Column || first.Row != second.Row;
        }

        /// <summary>
        /// Méthode qui retourne un boolean 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Equals(Position? p)
        {
            if (p is null)
            {
                return false;
            }
            return Column == p.Column && Row == p.Row;
        }
    }
}
 