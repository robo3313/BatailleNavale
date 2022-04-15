namespace Jeu
{
    public class Engine
    {
        int MapSize;
        public Fleet Fleet1 = new();
        //Fleet Fleet2 = new();
        public List<Position> AttackPositions = new();
        public Grid Grid = new();

        public Engine()
        {

        }

        public void InitMap(int size)
        {
            MapSize = size;
        }

        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            Position[] coordinates = Position.createFromStringArray(newCoordinates);
            CheckcoordinatesInMap(coordinates);
            CheckBoatCollisions(coordinates);
            CheckBoatContinuity(coordinates);
            Fleet1.AddBoat(name, type, coordinates);
            Grid.AddBoat(new Boat(name, type, coordinates));
        }

        public void Attack(Position coordinates)
        {
            try
            {
                CheckAttackInMap(coordinates);
                CheckAlreadyAttacked(coordinates);
                AttackPositions.Add(coordinates);
                Grid.AddImpact(coordinates);
                Console.WriteLine("Attaque: {0}", coordinates.ToString());
                Boat? hit = Fleet1.Attack(coordinates);
                if (hit is not null)
                {
                    if (!hit.Alive)
                    {
                        foreach (KeyValuePair<Position, bool> pos in hit.Positions)
                        {
                            Grid.AddImpact(pos.Key);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pas d'impact");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'attaque : {0}", e.Message);
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

        //Penser a modifier Fleet1
        public void CheckBoatCollisions(Position[] coordinates)
        {
            foreach (Position testedBoatPosition in coordinates)
            {
                if (Fleet1.BoatPositions.Contains(testedBoatPosition))
                {
                    Console.WriteLine("Identified collision for position {0}", testedBoatPosition);
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
                    throw new Exception("Bateau inconsistent " + previousCoor + " " + coor);
                }
                previousCoor = coor;
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

        public void setFleet(Fleet fl)
        {
            Fleet1 = fl;
            foreach (Boat b in fl.UserFleet)
            {
                Grid.AddBoat(b);
            }
        }

        public void DisplayFleets()
        {
            Fleet1.Display();
        }

        public void DisplayGrid()
        {
            Grid.Display();
        }
    }
}
