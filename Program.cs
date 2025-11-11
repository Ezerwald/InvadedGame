using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.Rooms;

namespace StarshipGame
{
    internal class Program
    {
        private static void Main()
        {
            var world = new GameWorld();

            Room room1 = new EmptyRoom("EmptyRoom 1");
            Room room2 = new OxygenRoom("OxygenRoom 1");

            world.AddObject(room1);
            world.AddObject(room2);
            world.AddObject(
                new Connector(
                    room1,
                    room2,
                    ConnectorType.Corridor,
                    "Connector 1"
                )
            );

            Actor actor1 = new CrewActor("Vlad", room1);

            world.AddObject(actor1);

            GameAction moveAction = new MoveAction(room2);
            GameAction breakAction = new BreakRoomAction();
            GameAction repairAction = new RepairRoomAction();

            List<GameAction> actions = [moveAction, breakAction, repairAction];
            foreach (GameAction action in actions)
            {
                action.Execute(world, actor1);
            }

        }
    }
}