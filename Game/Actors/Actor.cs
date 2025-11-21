using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (plannedActions.Count <= 0) 
            {
                return;
            }

            var action = plannedActions[0];
            plannedActions.RemoveAt(0);

            action.Execute(world, this, deltaTime);
        }

        public void StartExecution()
        {
            Console.WriteLine($"Actor {Name} starts action execution. {plannedActions.Count} actions left");
            pending = true;
        }

        public void EndExecution() 
        {
            Console.WriteLine($"Actor {Name} finished action execution. {plannedActions.Count} actions left");
            pending = false; 
        }

        public override void Update(GameWorld world, float deltaTime)
        {
            base.Update(world, deltaTime);

            if (pending)
            {
                ExecuteNextAction(world, deltaTime);
                EndExecution();
            }
        }


        // In future:
        // - add relative location in room for rendering
        // - add render method
    }
}
