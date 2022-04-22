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
        /// La fonction AddBoat ajoute le bateau en procédent de la façon suivante :
        /// Elle vérifie avec CheckcoordinatesInMap si les coordonnées sont possibles (contre exemple : A12 ; Z3).
        /// Elle vérifie ensuite à l'aide de CheckBoatCollisions que les bateaux ne se superposent pas.
        /// CheckBoatContinuity s'assure que le bateau est droit (exemple : E6, E7, E8).
        /// Enfin, une fois ces trois vérifications faites, elle crée le bateau et l'ajoute à la flotte "MyFleet" et l'insère par la suite sur la grille du joueur.
        public void AddBoat(string name, string type, string[] newCoordinates)
        {
            Position[] coordinates = Position.createFromStringArray(newCoordinates);
            CheckcoordinatesInMap(coordinates);
            CheckBoatCollisions(coordinates);
            CheckBoatContinuity(coordinates);
            MyFleet.AddBoat(name, type, coordinates);
            MyGrid.AddBoat(new Boat(name, type, coordinates));
        }
        /// ReceiveAttack s'occupe, si aucune erreur n'est détectée en son sein, d'enregistrer l'attaque sur la Grille et de vérifier si un bateau est présent sur la case attaquée.
        public int ReceiveAttack(Position coordinates)
        {
            /// Ici, on tente d'ajouter l'impact à la grille "MyGrid".
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
            /// La coordonnée rentrée n'est pas dans la grille et/ou est identique à une précédente attaque provenant du même joueur.
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de l'attaque : {0}", e.Message);
            }
            return 0;
        }
        /// Attack se charge de vérifier la possibilité de l'attaque en prenant en compte les coordonnées.
        /// CheckAttackInMap et CheckAlreadyAttacked analysent l'attaque proposée et la grille actuelle du joueur visé (donc grille 1 de la cible / grille 2 de l'attaquant).
        /// Une fois ces deux fonctions exécutées sans erreur, l'attaque est ajoutée à la Grille 2 du Joueur attaquant.
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
        /// CheckcoordinatesInMap vérifie les coordonnées entrée lors de la création d'un bateau et renvoie un message d'erreur si le bateau ne peut-être placé aux coordonnées données par le joueur.
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

        //Penser a modifier Fleet1
        /// CheckBoatCollisions vérifie si deux bateaux se superposent.
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
        /// CheckBoatContinuity empêche la création d'un bateau qui ne serait ni horizontal ni vertical.
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
        /// CheckAttackInMap empêche l'attaque d'un joueur s'il choisit une case en dehors de la grille.
        public void CheckAttackInMap(Position coordinates)
        {
            if (coordinates.Column < 'A' || coordinates.Column > 'J' || coordinates.Row < 1 || coordinates.Row > 10)
            {
                throw new ErrorException("Impossible d'attaquer en " + coordinates.ToString());
            }
        }
        /// CheckAlreadyAttacked s'emploie lors d'une nouvelle attaque d'un joueur et permet de dire au joueur s'il a déjà attaqué dans cette même coordonnée au-part-avant.
        public void CheckAlreadyAttacked(Position coordinates)
        {
            if (SentAttackPositions.Contains(coordinates))
            {
                throw new ErrorException("Déjà attaqué en " + coordinates.ToString());
            }
        }
        /// setFleet crée une Flotte dans la grille d'attaque adverse (grille 2) plaçant les bateaux de l'adversaire sur cette grille afin de faire corroborer les attaques du joueur avec les placements de l'adversaire.
        public void setFleet(Fleet fl)
        {
            EnemyFleet = fl;
            foreach (Boat b in fl.UserFleet)
            {
                EnemyGrid.AddBoat(b);
            }
        }
        /// DisplayGrids affiche les grilles.
        public void DisplayGrids()
        {
            Console.Clear();
            MyGrid.Display();
            EnemyGrid.Display();
        }
        /// Display Game affiche les deux grilles d'un joueur et cache les bateaux adverses dans la grille 2 (grille permettant au joueur d'attaquer).
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
