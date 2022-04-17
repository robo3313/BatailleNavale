using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jeu
{
    public class NavalMessage
    {
        public int Type { get; set; }
        public string? Content { get; set; }
        [JsonInclude]
        public SerialFleet? Fleet { get; set; }
        [JsonInclude]
        public Position? Position { get; set; }

        public NavalMessage() {}

        static public NavalMessage CreateFromError()
        {
            NavalMessage res = new();
            res.Type = -1;
            return res;
        }

        static public NavalMessage CreateFromFleet(Fleet fleet)
        {
            NavalMessage res = new();
            res.Type = 2;
            res.Fleet = new(fleet);
            return res;
        }

        static public NavalMessage CreateFromAttack(Position pos)
        {
            NavalMessage res = new();
            res.Type = 3;
            res.Position = pos;
            return res;
        }
    }
}
