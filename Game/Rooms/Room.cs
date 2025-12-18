using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvadedGame.Game.Rooms
{
    public abstract class Room : GameObject, IFormattable
    {
        public bool IsOperational { get; set; } = true;

        public Room(string name):base(name) { }

        public override string ToString()
            => ToString("short", null);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            format = format?.ToLowerInvariant();

            return format switch
            {
                "short" => Name,
                "status" => $"{Name} ({(IsOperational ? "Operational" : "Broken")})",
                "debug" => $"Room(Name={Name}, IsOperational={IsOperational})",
                _ => Name
            };
        }
    }
}
