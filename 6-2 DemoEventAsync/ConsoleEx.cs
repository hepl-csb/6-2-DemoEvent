using System;
using System.Threading;

namespace _11_DemoEvent
{
    internal class ConsoleEx
    {
        private static Mutex _mutex = new Mutex();

        public static void WriteLine(string text, ConsoleColor color)
        {
            _mutex.WaitOne();
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            _mutex.ReleaseMutex();
        }
    }
}
