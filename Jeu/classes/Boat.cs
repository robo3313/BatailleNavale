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
    }
}