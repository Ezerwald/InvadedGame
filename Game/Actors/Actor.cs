using InvadedGame.Engine;
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

        // In future:
        // - add relative location in room for rendering
        // - add render method

        protected Actor(string name, Room startingRoom)
            : base(name)
        {
            CurrentRoom = startingRoom;
        }
    }
}
