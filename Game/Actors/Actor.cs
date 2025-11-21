using InvadedGame.Engine;
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
        public event Action<Actor>? AllActionsCompleted;

        public Room CurrentRoom { get; internal set; }

        private List<Action> plannedActions = new();
        
        protected Actor(string name, Room startingRoom)
            : base(name)
        {
            CurrentRoom = startingRoom;
        }

        public void PlanAction(Action action)
        {
            plannedActions.Add(action);
        }

        public void ExecuteNextAction()
        {
            if (plannedActions.Count <= 0) 
            {
                return;
            }

            Action action = plannedActions[0];
            action.Invoke();
            plannedActions.RemoveAt(0);

            if (plannedActions.Count <= 0)
            {
                AllActionsCompleted?.Invoke(this);
            }
        }

        public void ClearPlannedActions()
        {
            plannedActions.Clear();
        }


        // In future:
        // - add relative location in room for rendering
        // - add render method
    }
}
