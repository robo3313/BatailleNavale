namespace Jeu
{
    class Fleet
    {
        List<Boat> boats;

        public Fleet()
        {
            boats = new List<Boat>();
        }

        public void AddBoat(Boat newBoat)
        {
            boats.Add(newBoat);
        }
    }
}
