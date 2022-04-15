using Jeu;

Grid g = new();

g.Display();

Position impact1 = new('G', 8); 
g.AddImpact(impact1);

g.Display();

/*engine

Fleet fleet1 = new Fleet();
fleet1.AddBoat("Willy", "Orque", new string[] { "A1", "A2", "A3" });


Boat b = new ("un", "ulysse", new string[] { "A1", "A2", "A3"});
g.AddBoat(b);*/