namespace Jeu
{
    public class Engine
    {
        int MapSize;
        public Fleet Fleet1 = new();
        //Fleet Fleet2 = new();
        public List<Position> AttackPositions = new();

        public Engine()
        {

        }

        public void InitMap(int size)
        {
            MapSize = size;
        }

        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            Fleet1.AddBoat(name, type, newCoordinates);
        }

        public void Attack(Position coordinates)
        {
            try
            {
                CheckAttackInMap(coordinates);
                CheckAlreadyAttacked(coordinates);
                AttackPositions.Add(coordinates);
                if (Fleet1.Attack(coordinates))
                {
                    Console.WriteLine("Touche en {0} !", coordinates);
                }
                Console.WriteLine("Added Impact : " + coordinates.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'attaque : {0}", e.Message);
            }
        }

        public void CheckAttackInMap(Position coordinates)
        {
            if (coordinates.Column < 'A' || coordinates.Column > 'J' || coordinates.Row < 1 || coordinates.Row > 10)
            {
                throw new Exception("Impossible d'attaquer en " + coordinates.ToString());
            }
        }
        public void CheckAlreadyAttacked(Position coordinates)
        {
            if (AttackPositions.Contains(coordinates))
            {
                throw new Exception("Déjà attaqué en " + coordinates.ToString());
            }
        }

        public void DisplayAttackPositions()
        {
            Console.Write("Attack positions : ");
            foreach (Position pos in AttackPositions)
            {
                Console.Write(pos + " ");
            }
            Console.WriteLine();
        }

        public void DisplayFleets()
        {
            Fleet1.Display();
        }
    }
}
