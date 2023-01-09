using System;

namespace Influence
{
    public class Debug
    {
        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format($"[Log] {message}"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format($"[Warning] {message}"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format($"[Error] {message}"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format($"[Info] {message}"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void CheckError()
        {

        }

    }
}
