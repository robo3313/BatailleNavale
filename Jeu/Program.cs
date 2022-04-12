using Jeu;

string[] positions = { "A1", "A2", "A3" };

Engine engine = new Engine();

engine.positionBoat("Requin", "Torpilleur", new string[] { "A1", "A2" });


engine.positionBoat("Requin", "Torpilleur", new string[] { "Z432", "Z423" });

engine.positionBoat("Requin", "Torpilleur", new string[] { "Z10", "B3" });