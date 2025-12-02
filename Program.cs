using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.GamePhases;
using InvadedGame.Game.Helpers;
using InvadedGame.Game.Rooms;
using InvadedGame.Game.Systems;

namespace StarshipGame
{
    internal class Program
    {
        private static void Main()
        {
            var world = new GameWorld();

            // Initialize Rooms
            Room emptyRoom1 = new EmptyRoom("'EmptyRoom 1'");
            world.AddObject(emptyRoom1);

            Room emptyRoom2 = new EmptyRoom("'EmptyRoom 2'");
            world.AddObject(emptyRoom2);

            // Initialize Connectors
            world.AddObject(new Connector(emptyRoom1, emptyRoom2, ConnectorType.Corridor, "Connector 1"));

            // Initialize Actors
            world.AddObject(new CrewActor("Vlad", emptyRoom1));
            world.AddObject(new CrewActor("Stefan", emptyRoom2));

            // Initialize Oxygen System
            world.AddObject(new OxygenSystem("Oxygen System", 5));

            // Initialize Phases Manager
            world.AddObject(new PhaseManager("Phase Manager", world));

            world.Start();

            while (world.Running)
            {
                world.Update();
            }
        }
    }
}