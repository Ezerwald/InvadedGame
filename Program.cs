using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.GamePhases;
using InvadedGame.Game.Rooms;
using InvadedGame.Game.Systems;

namespace StarshipGame
{
    internal class Program
    {
        private static void Main()
        {
            var world = new GameWorld();

            Room room1 = new EmptyRoom("EmptyRoom 1");
            world.AddObject(room1);

            Room room2 = new EmptyRoom("EmptyRoom 2");
            world.AddObject(room2);

            Connector connector1_2 = new Connector(room1, room2, ConnectorType.Corridor, "Connector 1");
            world.AddObject(connector1_2);

            Actor actor1 = new CrewActor("Vlad", room1);
            world.AddObject(actor1);


            // Actions initialization

            GameAction moveAction = new MoveAction(room2);
            GameAction breakAction = new BreakRoomAction();
            GameAction repairAction = new RepairRoomAction();

            // Planning actions for actor
            actor1.PlanAction(moveAction);
            actor1.PlanAction(breakAction);

            // Oxygen System
            OxygenSystem oxygenSystem = new OxygenSystem("Oxygen System", 5);
            world.AddObject(oxygenSystem);

            // Phases initialization
            PlanningPhaseController planningController = new PlanningPhaseController();

            ExecutionPhaseController executionController = new ExecutionPhaseController();
            
            EndPhaseController endController = new EndPhaseController();

            PhaseManager phaseManager = new PhaseManager(
                "Phase Manager", 
                world, 
                planningController, 
                executionController, 
                endController
            );
            world.AddObject(phaseManager);

            world.Start();

            while (world.Running)
            {
                world.Update();

                Console.Read();
            }
        }
    }
}