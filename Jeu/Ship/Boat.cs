namespace Jeu
{
    class Boat
    {
        String Name;
        String Type;
        Dictionary<Position, bool> Positions;
        bool Alive;
        
        public Boat(string name, string type, string[] positions)
        {
            Name = name;
            Type = type;
            Positions = new ();
            Position newPosition;

            foreach (string pos in positions)
            {
                newPosition = Position.createFromString(pos);
                Positions.Add(newPosition, false);
            }
            Alive = true;
        }
        // affiche name and type of boat
        public void WriteInfo()
        {
           Console.WriteLine("Mon nom est :{0}", Name);
           Console.WriteLine("Mon type est : {0}", Type);
           foreach(KeyValuePair<String, bool> pair in Positions)
            {
                Console.WriteLine("Ma position est : {0}  {1}", pair.Key, pair.Value);
            }
        }

    }
}