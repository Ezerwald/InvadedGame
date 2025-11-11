using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actors
{
    public class CrewActor : Actor
    {
        public CrewActor(string name, Room startingRoom) : base(name, startingRoom) {}
    }
}
