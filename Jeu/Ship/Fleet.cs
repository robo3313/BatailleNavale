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
            BoatPositions = new();
            UserFleet = new List<Boat>();
        }

        /// <summary>
        /// constructeur de la classe Fleet
        /// </summary>
        /// <param name="listboat"></param>
        public Fleet(List<Boat> listboat)
        {
            UserFleet = listboat;
        }

        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            try
            {
                Position[] coordinates = Position.createFromStringArray(newCoordinates);
                CheckcoordinatesInMap(coordinates);
                CheckBoatCollisions(coordinates);
                Boat b = new(name, type, coordinates);

                UserFleet.Add(b);
                foreach (Position pos in coordinates)
                {
                    BoatPositions.Add(pos);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la création du bateau : {0}", e.Message);
            }
        }

        public void CheckcoordinatesInMap(Position[] coordinates)
        {
            foreach (Position pos in coordinates)
            {
                if (pos.Column < 'A' || pos.Column > 'J' || pos.Row < 1 || pos.Row > 10)
                {
                    throw new Exception("Impossible de placer un bateau en " + pos.ToString());
                }
            }
        }

        public void CheckBoatCollisions(Position[] coordinates)
        {

            foreach (Position testedBoatPosition in coordinates)
            {
                if (BoatPositions.Contains(testedBoatPosition))
                {
                    throw new Exception("Impossible de placer un bateau en " + testedBoatPosition);
                }
            }
        }

        public void CheckBoatContinuity(Position[] coordinates)
        {
        }
     }
}
