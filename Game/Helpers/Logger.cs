using InvadedGame.Engine;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace InvadedGame.Game.Helpers
{
    public static class Logger
    {
        public static bool EnableLogger { get; set; } = true;
        public static bool EnableDebug { get; set; } = false;
        public static bool EnableInfo { get; set; } = true;
        public static bool EnableWarn { get; set; } = true;
        public static bool EnableError { get; set; } = true;

        private static string Timestamp =>
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        private static void Write(string level, string message) =>
            Console.WriteLine($"{Timestamp} {level,-5}| {message}");

        public static void Debug(string message, GameObject? obj = null)
        {
            if (!EnableLogger)
            {
                return;
            }

            if (EnableDebug)
                Write("DEBUG", Format(message, obj));
        }

        public static void Info(string message, GameObject? obj = null)
        {
            if (!EnableLogger)
            {
                return;
            }

            if (EnableInfo)
                Write("INFO", Format(message, obj));
        }

        public static void Warn(string message, GameObject? obj = null)
        {
            if (!EnableLogger)
            {
                return;
            }

            if (EnableWarn)
                Write("WARN", Format(message, obj));
        }

        public static void Error(string message, GameObject? obj = null)
        {
            if (!EnableLogger)
            {
                return;
            }

            if (EnableError)
                Write("ERROR", Format(message, obj));
        }

        private static string Format(string message, GameObject? obj) =>
            obj == null ? message : $"{obj.Name}: {message}";

        public static void PauseAndClear(string notification = null)
        {
            Console.WriteLine($">> Press ENTER to continue <<");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
