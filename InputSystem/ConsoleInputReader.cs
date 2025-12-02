using InvadedGame.Game.Interfaces;

namespace InvadedGame.InputSystem
{
    public class ConsoleInputReader : IInputReader
    {
        public bool TryRead(out string input)
        {
            input = Console.ReadLine();
            return true;
        }
    }

}
