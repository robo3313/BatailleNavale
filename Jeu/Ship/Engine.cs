namespace Jeu
{
    public class Engine
    {
        public Fleet MyFleet = new();
        public Fleet EnemyFleet = new();
        public List<Position> ReceivedAttackPositions = new();
        public Grid MyGrid = new();
        public Grid EnemyGrid = new();
        public List<Position> SentAttackPositions = new();

        /// <summary>
        /// Constructeur par défaut de la classe Engine
        /// </summary>
        public Engine() {}

        /// <summary>
        /// Permet d'ajouter un Bateau dans la flotte du joueur
        /// </summary>
        /// <param type="string" name="name">Le nom du bateau</param>
        /// <param name="type">Le type de bateau (pas utilisé pour l'instant)</param>
        /// <param name="newCoordinates">Les coordonées du bateau</param>
        /// <exception cref="ErrorException">En cas de coordonnées incorrectes</exception>
        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            Position[] coordinates = Position.createFromStringArray(newCoordinates);
            CheckcoordinatesInMap(coordinates);
            CheckBoatCollisions(coordinates);
            CheckBoatContinuity(coordinates);
            MyFleet.AddBoat(name, type, coordinates);
            MyGrid.AddBoat(new Boat(name, type, coordinates));
        }

        /// <summary>
        /// Vérifie si l'attaque aux coordonées de la Position touche un bateau de notre flotte
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>2 Si toute la flotte est coulée, 1 si un bateau est touché, 0 si l'attaque a échoué</returns>
        public int ReceiveAttack(Position coordinates)
        {
            try
            {
                MyGrid.AddImpact(coordinates);
                //Console.WriteLine("Attaque: {0}", coordinates.ToString());
                Boat? hit = MyFleet.Attack(coordinates);
                if (hit is not null)
                {
                    if (!hit.Alive)
                    {
                        foreach (KeyValuePair<Position, bool> pos in hit.Positions)
                        {
                            MyGrid.AddImpact(pos.Key);
                        }
                        return MyFleet.CountAliveBoats() == 0 ? 2 : 1;
                    }
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'attaque : {0}", e.Message);
            }
            return 0;
        }

        /// <summary>
        /// Vérifie si l'attaque aux coordonées Position touche un bateau de la flotte adverse
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>2 si tous les bateaux adverses sont coulés, 1 si un bateau a été touché, 0 si aucun bateau n'a été touché</returns>
        public int Attack(Position coordinates)
        {
            CheckAttackInMap(coordinates);
            CheckAlreadyAttacked(coordinates);
            SentAttackPositions.Add(coordinates);
            EnemyGrid.AddImpact(coordinates);
            //Console.WriteLine("Attaque: {0}", coordinates.ToString());
            Boat? hit = EnemyFleet.Attack(coordinates);
            if (hit is not null)
            {
                if (!hit.Alive)
                {
                    foreach (KeyValuePair<Position, bool> pos in hit.Positions)
                    {
                        EnemyGrid.AddImpact(pos.Key);
                    }
                    return EnemyFleet.CountAliveBoats() == 0 ? 2 : 1;
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Vérifie que les coordonées sont bien comprises dans la carte
        /// </summary>
        /// <param name="coordinates"></param>
        /// <exception cref="ErrorException"></exception>
        public void CheckcoordinatesInMap(Position[] coordinates)
        {
            foreach (Position pos in coordinates)
            {
                if (pos.Column < 'A' || pos.Column > 'J' || pos.Row < 1 || pos.Row > 10)
                {
                    throw new ErrorException("Impossible de placer un bateau en " + pos.ToString());
                }
            }
        }

        /// <summary>
        /// Vérifie qu'il n'y a pas déjà un bateau sur les coordonées
        /// </summary>
        /// <param name="coordinates"></param>
        /// <exception cref="ErrorException"></exception>
        public void CheckBoatCollisions(Position[] coordinates)
        {
            foreach (Position testedBoatPosition in coordinates)
            {
                if (EnemyFleet.BoatPositions.Contains(testedBoatPosition))
                {
                    Console.WriteLine("Identified collision for position {0}", testedBoatPosition);
                    throw new ErrorException("Collision en " + testedBoatPosition);
                }
            }
        }

        /// <summary>
        /// Vérifie que les coordonées se suivent et peuvent bien représenter un bateau
        /// </summary>
        /// <param name="coordinates"></param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Vérifie que les coordonnées de l'attaque sont bien dans la carte
        /// </summary>
        /// <param name="coordinates"></param>
        /// <exception cref="ErrorException"></exception>
        public void CheckAttackInMap(Position coordinates)
        {
            if (coordinates.Column < 'A' || coordinates.Column > 'J' || coordinates.Row < 1 || coordinates.Row > 10)
            {
                throw new ErrorException("Impossible d'attaquer en " + coordinates.ToString());
            }
        }
        
        /// <summary>
        /// Vérifie que les coordonées n'ont pas déjà été attaquées
        /// </summary>
        /// <param name="coordinates"></param>
        /// <exception cref="ErrorException"></exception>
        public void CheckAlreadyAttacked(Position coordinates)
        {
            if (SentAttackPositions.Contains(coordinates))
            {
                throw new ErrorException("Déjà attaqué en " + coordinates.ToString());
            }
        }

        /// <summary>
        /// Permet de set la propriétée EnemyFleet et de l'initialiser correctement
        /// </summary>
        /// <param name="fl"></param>
        public void setFleet(Fleet fl)
        {
            EnemyFleet = fl;
            foreach (Boat b in fl.UserFleet)
            {
                EnemyGrid.AddBoat(b);
            }
        }

        /// <summary>
        /// Affichage simple des cartes des adversaires
        /// </summary>
        public void DisplayGrids()
        {
            Console.Clear();
            MyGrid.Display();
            EnemyGrid.Display();
        }

        /// <summary>
        /// Affiche les des cartes des adversaires
        /// </summary>
        public void DisplayGame()
        {
            Console.Clear();
            Console.WriteLine("         My map           |         Oppenent map    ");
            Console.WriteLine("   A B C D E F G H I J    |   A B C D E F G H I J   ");
            Console.WriteLine("1  {0}  | 1  {1}  ", MyGrid.getRowDisplay(0), EnemyGrid.getHiddenRowDisplay(0));
            Console.WriteLine("2  {0}  | 2  {1}  ", MyGrid.getRowDisplay(1), EnemyGrid.getHiddenRowDisplay(1));
            Console.WriteLine("3  {0}  | 3  {1}  ", MyGrid.getRowDisplay(2), EnemyGrid.getHiddenRowDisplay(2));
            Console.WriteLine("4  {0}  | 4  {1}  ", MyGrid.getRowDisplay(3), EnemyGrid.getHiddenRowDisplay(3));
            Console.WriteLine("5  {0}  | 5  {1}  ", MyGrid.getRowDisplay(4), EnemyGrid.getHiddenRowDisplay(4));
            Console.WriteLine("6  {0}  | 6  {1}  ", MyGrid.getRowDisplay(5), EnemyGrid.getHiddenRowDisplay(5));
            Console.WriteLine("7  {0}  | 7  {1}  ", MyGrid.getRowDisplay(6), EnemyGrid.getHiddenRowDisplay(6));
            Console.WriteLine("8  {0}  | 8  {1}  ", MyGrid.getRowDisplay(7), EnemyGrid.getHiddenRowDisplay(7));
            Console.WriteLine("9  {0}  | 9  {1}  ", MyGrid.getRowDisplay(8), EnemyGrid.getHiddenRowDisplay(8));
            Console.WriteLine("10 {0}  | 10 {1}  ", MyGrid.getRowDisplay(9), EnemyGrid.getHiddenRowDisplay(9));
        }
    }
}
