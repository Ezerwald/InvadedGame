using InvadedGame.Engine;
using InvadedGame.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Actions
{
    public abstract class Action
    {
        public string Name { get; }

        protected Action(string name)
        {
            Name = name;
        }

        public abstract void Execute(GameWorld world, Actor actor);
    }
}
