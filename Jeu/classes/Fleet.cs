namespace Jeu
{
    class Fleet
    {
        public List<Boat> boats;

        public Fleet()
        {
            boats = new List<Boat>();
        }

        public bool AddBoat()
        {
            Boat tmp = new Boat("Requin", "Torpilleur", new string[] { "A1", "A2" });
            boats.Add(tmp);
            tmp = new Boat("Espadon", "Torpilleur", new string[] { "D1", "D2" });
            boats.Add(tmp);
            tmp = new Boat("Baline", "Croiseur", new string[] { "E1", "F1", "G1" });
            boats.Add(tmp);
            tmp = new Boat("Orque", "Croiseur", new string[] { "G1", "G2", "G3" });
            boats.Add(tmp);
            tmp = new Boat("Kraken", "Vaisseau-mère", new string[] { "J6", "J7", "J8", "J9" });
            boats.Add(tmp);
            return true;
        }
    }
}
