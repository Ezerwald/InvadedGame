using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using InvadedGame.Engine;

namespace InvadedGame.Game.Rooms
{
    public enum RoomState { Powered, Unpowered }

    public class Room : GameObject
    {
        public RoomState State { get; set; } = RoomState.Powered;
        public List<Connector> Connectors { get; } = new List<Connector>();

        public Room(string name):base(name) { }

        public override string ToString() => $"{Name} ({State})";
    }
}
