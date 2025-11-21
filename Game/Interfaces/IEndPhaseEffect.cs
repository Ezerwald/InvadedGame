using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Interfaces
{
    public interface IEndPhaseEffect
    {
        void ExecuteEndPhaseEffect(GameWorld world, float deltaTime);

        event Action<GameObject>? EndPhaseEffectCompleted; 
    }

}
