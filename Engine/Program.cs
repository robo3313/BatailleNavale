using Jeu;


Engine e = new();

e.AddBoat("Un", "Corvette", new string[] { "A1", "A2", "A3" });

e.DisplayFleets();

e.Attack(new Position('A', 1));

e.Attack(new Position('A', 3));

e.Attack(new Position('B', 4));

e.Attack(new Position('A', 11));

e.DisplayFleets();
