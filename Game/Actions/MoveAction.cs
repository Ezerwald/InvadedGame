using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Exceptions;
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

            Connector? connector =
                ConnectorsHelper.GetConnector(actorRoom, TargetRoom, world);

            if (connector == null)
                throw new MovementException(actorRoom, TargetRoom, "no connector exists");

            if (!connector.IsOpen)
                throw new MovementException(actorRoom, TargetRoom, "connector is closed");

            actor.CurrentRoom = TargetRoom;
            Logger.Render($"Moves to {TargetRoom.Name}.", actor);
        }


        public override object Clone()
        => new MoveAction(TargetRoom);
    }
}
