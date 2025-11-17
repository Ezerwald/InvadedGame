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

        public Room(string name):base(name) { }

        public override void Update(GameWorld world, float deltaTime)
        {
            Console.WriteLine($"Room {this.Name} was updated");
        }

        public override string ToString() => $"{Name} ({(IsOperational ? "Operational" : "Broken")})";

    }
}
