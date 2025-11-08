using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InvadedGame.Game.Rooms
{
    public abstract class Room : GameObject
    {
        public bool IsOperational { get; set; } = true;
        public List<Connector> Connectors { get; } = new List<Connector>();

        public Room(string name):base(name) { }
        
        public override string ToString() => $"{Name} ({(IsOperational ? "Operational" : "Broken")})";

        public Connector? GetConnectorTo(Room TargetRoom)
        {
            Connector? resultConnector = null;
            foreach (var connector in this.Connectors)
            {
                if (ReferenceEquals(TargetRoom, connector.GetOtherRoom(TargetRoom)))
                {
                    resultConnector = connector;
                }
            }

            return resultConnector;
        }
    }
}
