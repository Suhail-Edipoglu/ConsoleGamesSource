using ConsoleGames;
using System;
using System.Threading;

namespace ConsoleGameMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            HideCursor();
            Game game = new Game();
            //game.Run();

            Thread thread1 = new Thread(game.Run);
            thread1.Start();
            
            Thread.Sleep(1000);
            thread1.Join();
            Console.WriteLine(" Press X to exit");
        }

        public static void SetConsoleColor(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }

        public static void HideCursor()
        {
            Console.CursorVisible = false;
        }

        public static void ShowCursor()
        {
            Console.CursorVisible = true;
        }

        public static void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void DeleteChar()
        {
            if((Console.CursorLeft - 1) >= 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(' ');
            }
        }
    }
}
