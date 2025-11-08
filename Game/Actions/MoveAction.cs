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
    public class MoveAction : Action
    {
        public Room TargetRoom { get; }

        public MoveAction(Room targetRoom)
            : base($"Move to {targetRoom.Name}")
        {
            TargetRoom = targetRoom;
        }

        public override void Execute(GameWorld world, Actor actor)
        {
            // In future: validate connectors, door states, etc.
            actor.CurrentRoom = TargetRoom;
            Console.WriteLine($"{actor.Name} moves to {TargetRoom.Name}.");
        }
    }
}
