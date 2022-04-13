namespace Jeu
{
    /// <summary>
    /// classe Boat
    /// </summary>
    public class Boat
    {
        public string Name;
        public string Type;
        public Dictionary<string, bool> Positions;
        public bool Alive = false;

        /// <summary>
        /// constructeur de la classe Boat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="positions"></param>
        public Boat(string name, string type, string[] positions)
        {
            Name = name;
            Type = type;
            Positions = new Dictionary<string, bool>();
            foreach (string position in positions)
            {
                Positions.Add(position, false);
            }
            Alive = true;
        }
    }
}
