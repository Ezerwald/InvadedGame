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
                Logger.LogInfo($"Room {room.Name} was repaired");
            }
            else
            {
                Logger.LogInfo("Room doesn't need repairing");
            }
        }
    }
}
