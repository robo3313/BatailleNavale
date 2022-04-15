using Jeu;


Engine e = new();

e.AddBoat("Un", "Corvette", new string[] { "B1", "C1", "D1" });

e.DisplayFleets();

e.Attack(new Position('A', 1));
e.Attack(new Position('A', 3));

e.DisplayFleets();

e.DisplayGrid();