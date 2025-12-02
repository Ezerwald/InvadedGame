using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadedGame.Game.Interfaces
{
    public interface IInputReader
    {
        bool TryRead(out string input);
    }

}
