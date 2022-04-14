namespace Jeu
{
    /// <summary>
    /// classe Boat
    /// </summary>
    public class Boat
    {
        public string Name;
        public string Type;
        public Dictionary<Position, bool> Positions;
        public bool Alive = false;

        static public string[] Types = new string[] { "Frigate", "Galleon", "Battleship" };

        /// <summary>
        /// constructeur de la classe Boat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="positions"></param>

        public Boat(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Boat(string name, string type, Position[] positions)
        {
            Name = name;
            Type = type;
            Positions = new ();
            Position newPosition;

            foreach (Position pos in positions)
            {
                Positions.Add(pos, false);
            }
        }
        // affiche name and type of boat
        public void WriteInfo()
        {
            Console.WriteLine("Mon nom est :{0}", Name);
            Console.WriteLine("Mon type est : {0}", Type);
            if (Positions == null)
            {
                return;
            }
            foreach(KeyValuePair<Position, bool> pair in Positions)
            {
                Console.WriteLine("Ma position est : {0}  {1}", pair.Key.Column, pair.Key.Row);
            }
        }
        public override string ToString()
        {
            string res = Name + Type + Positions;
            return res;
        }

        public void checkType(string boatType)
        {
            if (Array.IndexOf(Types, boatType) < 0)
            {
                throw new Exception("Boat type " + boatType + " is not recognized");
            }
        }

    }
}