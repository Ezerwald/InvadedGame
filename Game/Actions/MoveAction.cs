using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

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

        public override void Execute(GameWorld world, Actor actor, float deltaTime)
        {
            Room actorRoom = actor.CurrentRoom;
            Connector? connector = ConnectorsHelper.GetConnector(actorRoom, this.TargetRoom, world);
            if (connector != null)
            {
                if (connector.IsOpen)
                {
                    actor.CurrentRoom = TargetRoom;
                    Logger.LogInfo($"Moves to {TargetRoom.Name}.", actor);
                }
                else
                {
                    Logger.LogWarning($"Connector between {actorRoom.Name} and {this.TargetRoom.Name} is closed");
                }
            }
            else
            {
                Logger.LogWarning($"No connector detected between {actorRoom.Name} and {this.TargetRoom.Name}");
            }
        }
    }
}
