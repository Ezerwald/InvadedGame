using InvadedGame.Game.Actions;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.Menu;

public class ConsoleMenuRenderer : IMenuRenderer
{
    public void Render(MenuModel model)
    {
        Console.Clear();

        switch (model)
        {
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

    private void RenderActorsList(ActorsListMenuModel menu)
    {
        Console.WriteLine("=== ACTORS ===");
        for (int i = 0; i < menu.Actors.Count; i++)
        {
            var actor = menu.Actors[i];
            Console.WriteLine($"{i + 1}. {actor.Name} ({actor.CurrentRoom.Name})");
        }
            

        Console.WriteLine();
        Console.WriteLine("X. Finish planning");
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
            List<GameAction> plannedActions = actor.PlannedActions;
            for (int i = 0; i < plannedActions.Count; i++)
            {
                Console.WriteLine($" - {plannedActions[i].Name}");
            }
        }

        Console.WriteLine() ;
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
            Console.WriteLine($"{i + 1}. {menu.Rooms[i].Name}");

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
