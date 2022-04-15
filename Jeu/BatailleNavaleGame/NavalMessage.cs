using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jeu
{
    public class NavalMessage
    {
        public int Type { get; set; }
        public string? Content { get; set; }
        public Fleet? Fleet { get; set; }
        public Position? Position { get; set; }

        public NavalMessage() {}

        static public NavalMessage CreateFromFleet(Fleet fleet)
        {
            NavalMessage res = new();
            res.Type = 2;
            res.Fleet = fleet;
            return res;
        }

        static public NavalMessage CreateFromAttack(Position position)
        {
            NavalMessage res = new();
            res.Type = 3;
            res.Position = position;
            return res;
        }
    }
}
