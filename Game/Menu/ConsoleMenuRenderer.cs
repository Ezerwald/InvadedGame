using InvadedGame.Game.Actions;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.Rooms;
using InvadedGame.Game.Systems;


namespace InvadedGame.Game.Menu
{
    public class ConsoleMenuRenderer : IMenuRenderer
    {
        public void Render(MenuModel model)
        {
            Console.Clear();

            switch (model)
            {
                case HomeScreenMenuModel home:
                    RenderHomeMenu(home);
                    break;

                case SpaceshipStateMenuModel ship:
                    RenderSpaceshipStateMenu(ship);
                    break;


                case ActorsListMenuModel actorsMenu:
                    RenderActorsList(actorsMenu);
                    break;

                case ActorMenuModel actorMenu:
                    RenderActorMenu(actorMenu);
                    break;

                case RoomSelectionMenuModel roomMenu:
                    RenderRoomSelection(roomMenu);
                    break;

                case ConfirmExitMenuModel exitMenu:
                    RenderConfirmExit(exitMenu);
                    break;
            }
        }

        private void RenderHomeMenu(HomeScreenMenuModel menu)
        {
            Console.WriteLine("=== HOME ===");
            Console.WriteLine("In this game you give orders to your crew, trying to keep your Spaceship operational.");
            Console.WriteLine("Plan actions for each crew member, repair broken rooms and keep an eye on your oxygen level!");
            Console.WriteLine();
            Console.WriteLine("Choose one of the options:");
            Console.WriteLine("1. Spaceship state");
            Console.WriteLine("2. Give orders to crew");
            Console.WriteLine();
            Console.WriteLine("X. Finish planning");
        }

        private void RenderSpaceshipStateMenu(SpaceshipStateMenuModel menu)
        {
            Console.WriteLine("=== SPACESHIP ===");

            var oxygen = menu.World.FindObjectOfType<OxygenSystem>();
            Console.WriteLine($"OXYGEN LEVEL: {oxygen?.OxygenValue}");

            Console.WriteLine("\nROOMS:");

            var rooms = menu.World.FindObjectsOfType<Room>();

            foreach (var room in rooms)
            {
                Console.WriteLine($"- {room.Name}:");
                Console.WriteLine($"   Operational: {room.IsOperational}");

                var connected = RoomHelper.GetConnectedRooms(room, menu.World);
                string connectedNames = connected.Count > 0
                    ? string.Join(", ", connected.Select(r => r.Name))
                    : "None";

                Console.WriteLine($"   Connected to: {connectedNames}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("B. Back");
        }


        private void RenderActorsList(ActorsListMenuModel menu)
        {
            Console.WriteLine("=== ACTORS ===");
            for (int i = 0; i < menu.Actors.Count; i++)
            {
                var actor = menu.Actors[i];
                Console.WriteLine($"{i + 1}. {actor.Name} ({actor.CurrentRoom.Name})");
            }


            Console.WriteLine();
            Console.WriteLine("B. Back");
        }

        private void RenderActorMenu(ActorMenuModel menu)
        {
            var actor = menu.Actor;
            Console.WriteLine($"=== {actor.Name} ===");
            Console.WriteLine($"CURRENT ROOM: {actor.CurrentRoom}");
            if (actor.DestinationRoom != actor.CurrentRoom)
            {
                Console.WriteLine($"DESTIANTION ROOM: {actor.DestinationRoom}");
            }

            if (actor.HasPlannedActions)
            {
                Console.WriteLine();
                Console.WriteLine("PLANNED ACTIONS:");
                int idx = 0;
                foreach (var plannedAction in actor.PlannedActions)
                {
                    Console.WriteLine($" - {plannedAction.Name}");
                    idx++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("CHOOSE ACTION TO PLAN:");
            for (int i = 0; i < menu.AvailableActions.Count; i++)
                Console.WriteLine($"{i + 1}. {menu.AvailableActions[i].ToString()}");

            Console.WriteLine();
            Console.WriteLine("B. Back");
        }

        private void RenderRoomSelection(RoomSelectionMenuModel menu)
        {
            Console.WriteLine($"=== Move {menu.Actor.Name} ===");
            Console.WriteLine("Choose destination:");

            for (int i = 0; i < menu.Rooms.Count; i++)
                Console.WriteLine($"{i + 1}. {menu.Rooms[i].ToString("status", null)}");

            Console.WriteLine();
            Console.WriteLine("B. Back");
        }


        private void RenderConfirmExit(ConfirmExitMenuModel menu)
        {
            Console.WriteLine(menu.Message);
            Console.WriteLine("Y. Yes");
            Console.WriteLine("N. No");
        }
    }
}