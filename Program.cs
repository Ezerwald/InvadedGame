using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvadedGame.Engine;
using InvadedGame.Game.Actions;
using InvadedGame.Game.Actors;
using InvadedGame.Game.GamePhases;
using InvadedGame.Game.Interfaces;
using InvadedGame.Game.ResourceTrackers;
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

            Room room2 = new OxygenRoom("OxygenRoom 1");
            world.AddObject(room2);

            Connector connector1_2 = new Connector(room1, room2, ConnectorType.Corridor, "Connector 1");
            world.AddObject(connector1_2);

            Actor actor1 = new CrewActor("Vlad", room1);
            world.AddObject(actor1);


            // Actions initialization

            GameAction moveAction = new MoveAction(room2);
            GameAction breakAction = new BreakRoomAction();
            GameAction repairAction = new RepairRoomAction();

            // Actions Execution 

            List<GameAction> actions = [moveAction, breakAction];
            foreach (GameAction action in actions)
            {
                action.Execute(world, actor1);
            }

            // Oxygen System
            OxygenTracker oxygenTracker = new OxygenTracker("Oxygen Tracker", 5);
            world.AddObject(oxygenTracker);

            OxygenSystem oxygenSystem = new OxygenSystem("Oxygen System", oxygenTracker);
            world.AddObject(oxygenSystem);

            // Phases initialization
            PlanningPhaseController planningController = new PlanningPhaseController("Planning Phase Controller");
            world.AddObject(planningController);

            ExecutionPhaseController executionController = new ExecutionPhaseController("Execution Phase Controller");
            world.AddObject(executionController);
            
            EndPhaseController endController = new EndPhaseController("End Phase Controller");
            world.AddObject(endController);

            PhaseManager phaseManager = new PhaseManager("Phase Manager",
                                                          world,
                                                          planningController, 
                                                          executionController, 
                                                          endController);
            world.AddObject(phaseManager);

            // World Update (1 loop)
            int deltaTime = 0;
            for (int i = 0; i < 5; i++)
            {
                world.Update(deltaTime);
            }
        }
    }
}