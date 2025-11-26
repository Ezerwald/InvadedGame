using InvadedGame.Engine;
using System.Runtime.InteropServices;

namespace InvadedGame.Game.Helpers
{
    public static class Logger
    {
        private static bool logDebug = true;
        private static bool logInfo = true;
        private static bool logWarn = true;

        public static void LogDebug(string message) { if (logDebug) { Console.WriteLine($"DEBUG| {message}"); } }

        public static void LogInfo(string message) { if (logInfo) { Console.WriteLine($"| {message}"); } }
        public static void LogInfo(string message, GameObject obj) { if (logInfo) { Console.WriteLine($"|   {obj.Name}: {message}"); } }

        public static void LogWarning(string message) { if (logWarn) { Console.WriteLine($"WARNING| {message}"); } }
        public static void LogWarning(string message, GameObject obj) { if (logWarn) { Console.WriteLine($"WARNING| {obj.Name}: {message}"); } }

    }
}
