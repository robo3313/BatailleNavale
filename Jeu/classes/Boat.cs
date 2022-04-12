namespace Jeu
{
    class Boat
    {
        String Name;
        String Type;
        Dictionary<String, bool> Positions;
        bool Alive;

        public Boat(string name, string type, string[] positions)
        {
            Name = name;
            Type = type;
            Positions = new Dictionary<String, bool>();
            foreach (string position in positions)
            {
                Positions.Add(position, false);
            }
            Alive = true;
        }
    }
}
