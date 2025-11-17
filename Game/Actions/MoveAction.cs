using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Actions
{
    public class MoveAction : GameAction
    {
        public Room TargetRoom { get; }

        public MoveAction(Room targetRoom)
            : base($"Move to {targetRoom.Name} action")
        {
            TargetRoom = targetRoom;
        }

        public override void Execute(GameWorld world, Actor actor)
        {
            Room actorRoom = actor.CurrentRoom;
            Connector? connector = ConnectorsHelper.GetConnector(actorRoom, this.TargetRoom, world);
            if (connector != null)
            {
                if (connector.IsOpen)
                {
                    actor.CurrentRoom = TargetRoom;
                    Console.WriteLine($"{actor.Name} moves to {TargetRoom.Name}.");
                }
                else
                {
                    Console.WriteLine($"Connector between {actorRoom.Name} and {this.TargetRoom.Name} is closed");
                }
            }
            else
            {
                Console.WriteLine($"No connector detected between {actorRoom.Name} and {this.TargetRoom.Name}");
            }
        }
    }
}
