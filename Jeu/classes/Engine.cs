namespace Jeu
{
    class Engine
    {
        int MapSize;
        Fleet Fleet1 = new Fleet();
        Fleet Fleet2 = new Fleet();

        public Engine()
        {

        }

        public void InitMap(int size)
        {
            MapSize = size;
        }

        public bool positionBoat(string name, string type, string[] positions)
        {
            Console.WriteLine("Tentative de positionnement d'un bateau {0}", name);
            try
            {
                Boat tmp = new Boat(name, type, positions);
                Console.WriteLine("Bateau bien positionné");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la création d'un bateau : ", e);
            }

            return true;
        }

    }
}
