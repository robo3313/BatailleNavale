using Jeu;


Engine e = new();

e.AddBoat("Un", "Corvette", new string[] { "C5", "C6", "C7" });

e.DisplayFleets();

e.Attack(new Position('A', 1));
e.Attack(new Position('A', 3));

e.DisplayFleets();

e.DisplayGrid();