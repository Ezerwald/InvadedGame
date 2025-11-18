using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game
{
    public interface IOncePerRound
    {
        void ExecuteRoundEffect(GameWorld world, float deltaTime);

        event Action<IOncePerRound>? Completed;
    }

}
