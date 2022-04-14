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

        /// <summary>
        /// méthode qui affiche la flotte
        /// </summary>
        public void DisplayFleet()
        {
            //List<Boat> listBoat = new List<Boat>();
            //listBoat.Add(new Boat("T1", "Torpilleur", new string[] { "A1", "A4" }));

            //Fleet fleet = new Fleet(new List<Boat>{ new Boat("T1", "Torpilleur", new string[] { "A1", "A4" }) });
            //fleet = new(listBoat);
        }
    }
}
