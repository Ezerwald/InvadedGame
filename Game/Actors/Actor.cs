using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actors
{
    public abstract class Actor : GameObject
    {
        public event Action<Actor>? ActionCompleted;

        public Room CurrentRoom { get; internal set; }

        private List<GameAction> plannedActions = new();

        public bool HasPlannedActions => plannedActions.Count > 0;

        public bool pending = false;

        protected Actor(string name, Room startingRoom)
            : base(name)
        {
            CurrentRoom = startingRoom;
        }

        public void PlanAction(GameAction action)
        {
            plannedActions.Add(action);
        }

        public void ExecuteNextAction(GameWorld world, float deltaTime)
        {
            var action = plannedActions[0];
            plannedActions.RemoveAt(0);

            action.Execute(world, this, deltaTime);

            ActionCompleted?.Invoke(this);
        }

        public void StartExecution()
        {
            Logger.LogInfo($"Starts action execution ({plannedActions.Count} left)", this);
            pending = true;
        }

        public void EndExecution() 
        {
            Logger.LogInfo($"Finishes action execution ({plannedActions.Count} left)", this);
            pending = false; 
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            if (!pending)
            {
                return;
            }

            ExecuteNextAction(world, deltaTime);
            EndExecution();
        }


        // In future:
        // - add relative location in room for rendering
        // - add render method
    }
}
