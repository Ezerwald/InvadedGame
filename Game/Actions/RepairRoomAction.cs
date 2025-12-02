using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actions
{
    public class RepairRoomAction : GameAction
    {
        public RepairRoomAction() : base($"Repair room action") { }

        public override void Execute(GameWorld world, Actor actor, float deltaTime)
        {
            Room room = actor.CurrentRoom;
            if (room.IsOperational != true)
            {
                room.IsOperational = true;
                Logger.Render($"Repairs {room.Name} room", actor);
            }
            else
            {
                Logger.Render($"Room {room.Name} doesn't need repairing", actor);
            }
        }
    }
}
