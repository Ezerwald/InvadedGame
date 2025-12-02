using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Rooms;

namespace InvadedGame.Game.Menu
{
    public abstract class MenuModel { }

    public class ActorsListMenuModel : MenuModel
    {
        public List<Actor> Actors { get; }
        public ActorsListMenuModel(List<Actor> actors) => Actors = actors;
    }

    public class ActorMenuModel : MenuModel
    {
        public Actor Actor { get; }
        public List<ActionTypes> AvailableActions { get; }

        public ActorMenuModel(Actor actor, List<ActionTypes> actions)
        {
            Actor = actor;
            AvailableActions = actions;
        }
    }

    public class RoomSelectionMenuModel : MenuModel
    {
        public Actor Actor { get; }
        public List<Room> Rooms { get; }

        public RoomSelectionMenuModel(Actor actor, List<Room> rooms)
        {
            Actor = actor;
            Rooms = rooms;
        }
    }

    public class ConfirmExitMenuModel : MenuModel
    {
        public string Message { get; } = "Finish planning and proceed to Execution Phase?";
    }

}
