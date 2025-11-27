using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actions
{
    public class RepairRoomAction : GameAction
    {
        public RepairRoomAction() : base($"Break room action") { }

        public override void Execute(GameWorld world, Actor actor, float deltaTime)
        {
            Room room = actor.CurrentRoom;
            if (room.IsOperational != true)
            {
                room.IsOperational = true;
                Logger.Info($"Repairs {room.Name} room", actor);
            }
            else
            {
                Logger.Info("Room doesn't need repairing");
            }
        }
    }
}
