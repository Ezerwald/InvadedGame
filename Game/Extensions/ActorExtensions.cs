using InvadedGame.Game.Actors;

namespace InvadedGame.Game.Extensions
{
    public static class ActorExtensions
    {
        public static bool IsBusy(this Actor actor)
        {
            return actor.HasPlannedActions;
        }
    }
}
