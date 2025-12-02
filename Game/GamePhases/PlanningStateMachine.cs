using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Menu;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.GamePhases
{
    public class PlanningStateMachine
    {
        public bool IsFinished { get; private set; } = false;

        public MenuModel CurrentMenu { get; private set; }

        private readonly GameWorld world;
        private Actor selectedActor;

        private readonly List<ActionTypes> baseActions = new()
        {
            ActionTypes.MoveAction,
            ActionTypes.RepairRoomAction,
            ActionTypes.BreakRoomAction
        };

        public PlanningStateMachine(GameWorld world)
        {
            this.world = world;
            ShowActorsList();
        }

        // ------------------------------
        // MENU TRANSITIONS
        // ------------------------------

        private void ShowActorsList()
        {
            var crewActors = world.FindObjectsOfType<CrewActor>().ToList(); // if needed can get all types of Actors (including enemy)
            List<Actor> actors = crewActors.Cast<Actor>().ToList();     

            CurrentMenu = new ActorsListMenuModel(actors);
        }

        private void ShowActorMenu(Actor actor)
        {
            selectedActor = actor;
            CurrentMenu = new ActorMenuModel(actor, baseActions);
        }

        private void ShowRoomSelectionMenu(Actor actor)
        {
            var connected = RoomHelper.GetConnectedRooms(actor.DestinationRoom, world);
            if (connected.Count <= 0) 
            {
                Logger.Warn($"No connected rooms found for {actor.DestinationRoom}");
            }
            CurrentMenu = new RoomSelectionMenuModel(actor, connected);
        }

        private void ShowConfirmExit()
        {
            CurrentMenu = new ConfirmExitMenuModel();
        }

        // ------------------------------
        // INPUT HANDLING
        // ------------------------------

        public void HandleInput(string input)
        {
            if (IsFinished) return;

            switch (CurrentMenu)
            {
                case ActorsListMenuModel aList:
                    HandleActorsListInput(input, aList);
                    break;

                case ActorMenuModel aMenu:
                    HandleActorMenuInput(input, aMenu);
                    break;

                case RoomSelectionMenuModel rMenu:
                    HandleRoomSelectionInput(input, rMenu);
                    break;

                case ConfirmExitMenuModel confirm:
                    HandleConfirmExitInput(input);
                    break;
            }
        }

        // ---- ACTORS LIST ----

        private void HandleActorsListInput(string input, ActorsListMenuModel menu)
        {
            if (input.Equals("X", StringComparison.OrdinalIgnoreCase))
            {
                ShowConfirmExit();
                return;
            }

            if (!int.TryParse(input, out int idx)) return;
            idx -= 1;

            if (idx < 0 || idx >= menu.Actors.Count) return;

            ShowActorMenu(menu.Actors[idx]);
        }

        // ---- ACTOR MENU ----

        private void HandleActorMenuInput(string input, ActorMenuModel menu)
        {
            if (input.Equals("B", StringComparison.OrdinalIgnoreCase))
            {
                ShowActorsList();
                return;
            }

            if (!int.TryParse(input, out int idx)) return;
            idx -= 1;

            if (idx < 0 || idx >= menu.AvailableActions.Count) return;

            ActionTypes chosenAction = menu.AvailableActions[idx];

            switch (chosenAction)
            {
                case ActionTypes.MoveAction:
                    ShowRoomSelectionMenu(menu.Actor);
                    break;

                case ActionTypes.RepairRoomAction:
                    AddRepairRoomAction(menu.Actor);
                    ShowActorMenu(menu.Actor);
                    break;

                case ActionTypes.BreakRoomAction:
                    AddBreakRoomAction(menu.Actor);
                    ShowActorMenu(menu.Actor);
                    break;
            }
        }

        // ---- ROOM SELECTION MENU ----

        private void HandleRoomSelectionInput(string input, RoomSelectionMenuModel menu)
        {
            if (input.Equals("B", StringComparison.OrdinalIgnoreCase))
            {
                ShowActorMenu(menu.Actor);
                return;
            }

            if (!int.TryParse(input, out int idx)) return;
            idx -= 1;

            if (idx < 0 || idx >= menu.Rooms.Count) return;

            Room target = menu.Rooms[idx];

            menu.Actor.DestinationRoom = target;

            AddMoveAction(menu.Actor, target);

            ShowActorMenu(menu.Actor);
        }

        // ---- FINISH ----

        private void HandleConfirmExitInput(string input)
        {
            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                IsFinished = true;
                return;
            }

            if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                ShowActorsList();
            }
        }

        // ------------------------------
        // ACTION ADDING
        // ------------------------------

        private void AddMoveAction(Actor actor, Room target)
        {
            actor.PlanAction(new MoveAction(target));
        }

        private void AddRepairRoomAction(Actor actor)
        {
            actor.PlanAction(new RepairRoomAction());
        }

        private void AddBreakRoomAction(Actor actor)
        {
            actor.PlanAction(new BreakRoomAction());
        }
    }
}
