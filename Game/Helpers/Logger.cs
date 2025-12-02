using InvadedGame.Engine;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace InvadedGame.Game.Helpers
{
    public static class Logger
    {
        public static bool EnableLogger { get; set; } = true;
        public static bool EnableDebug { get; set; } = false;
        public static bool EnableInfo { get; set; } = false;
        public static bool EnableWarn { get; set; } = true;
        public static bool EnableError { get; set; } = true;
        public static bool EnableRender { get; set; } = true;

        private static string Timestamp =>
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        private static void Write(string level, string message) =>
            Console.WriteLine($"{Timestamp} {level,-5}| {message}");

        public static void Debug(string message, GameObject? obj = null)
        {
            if (EnableDebug && EnableLogger)
                Write("DEBUG", Format(message, obj));
        }

        public static void Info(string message, GameObject? obj = null)
        {
            if (EnableInfo && EnableLogger)
                Write("INFO", Format(message, obj));
        }

        public static void Warn(string message, GameObject? obj = null)
        {
            if (EnableWarn && EnableLogger)
                Write("WARN", Format(message, obj));
        }

        public static void Error(string message, GameObject? obj = null)
        {
            if (EnableError && EnableLogger)
                Write("ERROR", Format(message, obj));
        }

        public static void Render(string message, GameObject? obj = null)
        {
            if (EnableRender && EnableLogger)
                Write("RENDER", Format(message, obj));
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
