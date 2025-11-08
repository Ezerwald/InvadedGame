using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Rooms
{
    public enum ConnectorType
    {
        Corridor,
        Vent
    }

    public class Connector : GameObject
    {
        public Room RoomA { get; }
        public Room RoomB { get; }
        public ConnectorType Type { get; }
        public bool IsOpen { get; set; } = true;


        public Connector(Room a, Room b, ConnectorType type, string? name = null)
            : base(name ?? $"{type} {a.Name}-{b.Name}")
        {
            RoomA = a;
            RoomB = b;
            Type = type;
        }
        

        public Room? GetOtherRoom(Room thisRoom)
        {
            if (ReferenceEquals(thisRoom, RoomA))
                return RoomB;

            if (ReferenceEquals(thisRoom, RoomB))
                return RoomA;

            return null;
        }

        public override string ToString() =>
            $"{Name}: {Type}, {(IsOpen ? "Open" : "Closed")}";
    }
}
