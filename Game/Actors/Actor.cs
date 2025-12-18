using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Exceptions;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Actors
{
    public abstract class Actor : GameObject
    {
        public event Action<Actor>? ActionCompleted;

        public Room CurrentRoom { get; internal set; }

        public Room DestinationRoom { get; internal set; }

        public ActionQueue<GameAction> PlannedActions { get; } = new();

        public bool HasPlannedActions => PlannedActions.Count > 0;

        public bool pending = false;

        protected Actor(string name, Room startingRoom)
            : base(name)
        {
            CurrentRoom = startingRoom;
            DestinationRoom = startingRoom;
        }

        public void PlanAction(GameAction action)
        => PlannedActions.Enqueue(action);

        public void ExecuteNextAction(GameWorld world, float deltaTime)
        {
            var action = PlannedActions.Dequeue();

            if (action == null)
                return;

            try
            {
                action.Execute(world, this, deltaTime);
            }
            catch (MovementException ex)
            {
                // Expected domain error (game rule violation)
                Logger.Warn(ex.Message, this);
            }
            catch (Exception ex)
            {
                // Unexpected error – should never happen, but we guard anyway
                Logger.Error($"Unexpected error during action execution: {ex.Message}", this);
            }
            finally
            {
                ActionCompleted?.Invoke(this);
            }
        }


        public void StartExecution()
        {
            Logger.Info($"Gets order to start action execution ({PlannedActions.Count} left)", this);
            pending = true;
        }

        public void EndExecution() 
        {
            Logger.Info($"Finishes action execution ({PlannedActions.Count} left)", this);
            pending = false;

            // Maybe refactor in future
            DestinationRoom = CurrentRoom;
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
