using ConsoleGames;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGameMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Conway's Game of Life";
            /*
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            if (args == null || args.Length == 0)
                Console.SetWindowPosition(0, 0);
            else
            {
                int xPos = Convert.ToInt32(args[0]);
                int yPos = Convert.ToInt32(args[1]);
                Console.SetWindowPosition(xPos, yPos);
            }
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            */

            //int x = Console.WindowWidth * Console.WindowHeight;
            // read int from console
            //int x = int.Parse(Console.ReadLine());
            //Console.WriteLine();
            //PrintNumbers(x); //158 47 7426 //211 50 10550
            //HideCursor();Console.ReadLine();

            //Console.Write("press 1 for game 1 or ");
            //Console.Write("press 2 for Conway's Game of Life: ");
            //int input = int.Parse(Console.ReadLine());
            int input = 2;

            switch (input)
            {
                case 1:
                    Clear();
                    Game1();
                    break;
                case 2:
                    Game2();
                    break;
                default:
                    break;
            }
        }

        public static void Game1()
        {
            Game game = new Game();
            game.Run();

            Thread thread1 = new Thread(game.Run);
            thread1.Start();

            Thread.Sleep(1000);
            thread1.Join();
            Console.WriteLine(" Press X to exit");
        }

        public static void Game2()
        {
            Conway.GameOfLife game = new Conway.GameOfLife();
            game.Run();
            ResetConsoleColor();
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

        // function to print out 0-9 in alternating colors per sequence (red, blue, green, yellow, magenta, cyan, white) for a total of 7426 characters
        public static void PrintNumbers(int x)
        {
            int counter = 0;
            int colorCounter = 0;
            int color = 0;
            while (counter < x)
            {
                switch (colorCounter)
                {
                    case 0:
                        color = 12;
                        break;
                    case 1:
                        color = 9;
                        break;
                    case 2:
                        color = 10;
                        break;
                    case 3:
                        color = 14;
                        break;
                    case 4:
                        color = 13;
                        break;
                    case 5:
                        color = 11;
                        break;
                    case 6:
                        color = 15;
                        break;
                    default:
                        break;
                }
                SetConsoleColor((ConsoleColor)color, ConsoleColor.Black);
                Console.Write(counter % 10);
                counter++;
                colorCounter++;
                if (colorCounter == 7)
                {
                    colorCounter = 0;
                }
            }
            ResetConsoleColor();
        }

        
    }
}
