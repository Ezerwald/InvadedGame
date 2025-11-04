using InvadedGame.Engine;
using InvadedGame.Game.Controllers;
using InvadedGame.Game.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Actors
{
    public abstract class Actor : GameObject
    {
        public Room CurrentRoom { get; internal set; }
        public Controller Controller { get; set; }

        protected Actor(string name, Room startingRoom, Controller controller)
            : base(name)
        {
            CurrentRoom = startingRoom;
            Controller = controller;
        }
    }
}
