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
    }
}
