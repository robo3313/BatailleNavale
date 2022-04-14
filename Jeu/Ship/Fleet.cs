using static System.Console;

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

        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            try
            {
                Position[] coordinates = Position.createFromStringArray(newCoordinates);
                CheckcoordinatesInMap(coordinates);
                CheckBoatCollisions(coordinates);
                CheckBoatContinuity(coordinates);
                Boat b = new(name, type, coordinates);

                UserFleet.Add(b);
                foreach (Position pos in coordinates)
                {
                    BoatPositions.Add(pos);
                }
                WriteLine("Added boat : " + b.ToString());
            }
            catch (Exception e)
            {
                WriteLine("Erreur lors de la création du bateau : {0}", e.Message);
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

        public void DisplayBoatPositions()
        {
            Write("Boat positions : ");
            foreach (Position pos in BoatPositions)
            {
                Write(pos+ " ");
            }
            WriteLine();
        }

        public void CheckBoatCollisions(Position[] coordinates)
        {
            DisplayBoatPositions();
            foreach (Position testedBoatPosition in coordinates)
            {
                if (BoatPositions.Contains(testedBoatPosition))
                {
                    WriteLine("Identified collision for position {0}", testedBoatPosition);
                    throw new Exception("Collision en " + testedBoatPosition);
                }
            }
        }

        public void CheckBoatContinuity(Position[] coordinates)
        {
            Position? previousCoor = null;
            foreach (Position coor in coordinates)
            {
                if (previousCoor is null)
                {
                    previousCoor = coor;
                    continue;
                }
                if (!coor.isNextTo(previousCoor))
                {
                    throw new Exception("Bateau inconsistent "+previousCoor+" "+coor);
                }
                previousCoor = coor;
            }

        }
     }
}
