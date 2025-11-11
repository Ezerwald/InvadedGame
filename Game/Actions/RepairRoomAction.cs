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
    public class RepairRoomAction : GameAction
    {
        public RepairRoomAction() : base($"Break room action") { }

        public override void Execute(GameWorld world, Actor actor)
        {
            Room room = actor.CurrentRoom;
            if (room.IsOperational != true)
            {
                room.IsOperational = true;
                Console.WriteLine($"Room {room.Name} was repaired");
            }
            else
            {
                Console.WriteLine("Room doesn't need repairing");
            }
        }
    }
}
