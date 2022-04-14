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
                Boat b = new(name, type, coordinates);

                UserFleet.Add(b);
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
    }

      /*  public void CheckBoatCollisions(Position[] coordinates)
        {
            
            foreach (string position in coordinates)
            {
                char letter = Char.ToUpper(position[0]);
                int number;
                // Analyse des coordinates qui ont passé la vérification pour savoir si un bateau est déjà en place sur les cases données.
                foreach (i in coordinates)
                {
                    if (letter + number == string[i])
                        throw new Exception("Impossible de placer un bateau en " + position + " car un bateau est déjà disposé sur cette case");
                    if (letter + numbers == string[i])
                        throw new Exception("Impossible de placer un bateau en " + position + " car un bateau est déjà disposé sur cette case");

                }

            }
           
        } */

 /*       public void CheckBoatContinuity(Position[] coordinates)
        {
            foreach (Position c in coordinates)

            {
                Console.WriteLine(coordinates[c]); 
            }
            
            
        }

    } */
} 
