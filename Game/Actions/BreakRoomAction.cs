using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Actions
{
    public class BreakRoomAction : GameAction
    {
        public BreakRoomAction() : base($"Break room action"){}

        public override void Execute(GameWorld world, Actor actor)
        {
            Room room = actor.CurrentRoom;

            if (room.IsOperational == true)
            {
                room.IsOperational = false;
                Console.WriteLine($"Room {room.Name} was broken");
            }
            else
            {
                Console.WriteLine("Room is already broken");
            }
        }
    }
}
