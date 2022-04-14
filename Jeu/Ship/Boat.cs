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
            Alive = true;
        }
        // affiche name and type of boat
        public void WriteInfo()
        {
           Console.WriteLine("Mon nom est :{0}", Name);
           Console.WriteLine("Mon type est : {0}", Type);
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

    }
}