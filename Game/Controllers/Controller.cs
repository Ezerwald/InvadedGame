using InvadedGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Controllers
{
    public abstract class Controller
    {
        public abstract void PlanActions(Actors.Actor actor, GameWorld world);
    }
}
