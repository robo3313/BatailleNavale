namespace Jeu
{
    /// <summary>
    /// classe correspondant à la flotte
    /// </summary>
    public class Fleet
    {
        /// <summary>
        /// propriété UserFleet qui est une liste d'objet Boat
        /// </summary>
        public List<Boat> UserFleet { get; set; }
        public List<Position> BoatPositions;


        public Fleet()
        {
            UserFleet = new();
            BoatPositions = new();
        }

        /// <summary>
        /// constructeur de la classe Fleet
        /// </summary>
        /// <param name="listboat"></param>
        public Fleet(List<Boat> listboat)
        {
            UserFleet = listboat;
            BoatPositions = new();
            foreach (Boat b in listboat)
            {
                foreach (KeyValuePair<Position, bool> pos in b.Positions)
                {
                    BoatPositions.Add(pos.Key);
                }
            }
        }

        public void AddBoat(string name, string type, Position[] coordinates)
        {
            try
            { 
                Boat b = new(name, type, coordinates);
                UserFleet.Add(b);
                foreach (Position pos in coordinates)
                {
                    BoatPositions.Add(pos);
                }
                Console.WriteLine("Added boat : " + b.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la création du bateau : {0}", e.Message);
            }
        }

        public Boat? Attack(Position coordinates)
        {
            int tmp;
            foreach (Boat boat in UserFleet)
            {
                tmp = boat.Attack(coordinates);
                if (tmp > 0)
                {
                    return boat;
                }
            }
            return null;
        }

        public void Display()
        {
            foreach (Boat b in UserFleet)
            {
                b.WriteInfo();
            }
        }

        public void DisplayBoatPositions()
        {
            Console.Write("Boat positions : ");
            foreach (Position pos in BoatPositions)
            {
                Console.Write(pos + " ");
            }
            Console.WriteLine();
        }
    }
}
