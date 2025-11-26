namespace InvadedGame.Game.Helpers
{
    public static class Logger
    {
        private static bool logDebug = true;
        private static bool logInfo = true;
        private static bool logWarn = true;

        public static void LogDebug(string message) { if (logDebug) { Console.WriteLine(message); } }

        public static void LogInfo(string message) { if (logInfo) { Console.WriteLine(message); } }

        public static void LogWarning(string message) { if (logWarn) { Console.WriteLine($"WARNING: {message}"); } }
    }
}
