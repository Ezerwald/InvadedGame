using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Interfaces
{
    public interface IPhaseController
    {
        void OnEnter(GameWorld world, float deltaTime);
        void OnExit(GameWorld world, float deltaTime);
        void Update(GameWorld world, float deltaTime);
    }

}
