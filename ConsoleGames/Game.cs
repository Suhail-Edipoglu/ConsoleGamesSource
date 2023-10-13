using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGames
{
    internal class Game
    {
        public bool end = false;

        public Game() { }

        public void Run()
        {
            Board board = new Board();

            board.GenerateMap("../../../Maps/Map1.xml");
            board.PrintBoard();
            Console.WriteLine(' ');

            if(board.field.Count == 0 || board.entities.Count == 0)
            {
                Console.WriteLine("Error: No player or field found");
                return;
            }

            ConsoleKeyInfo cki;

            do
            {
                // Store the current readkey inside the loop
                cki = Console.ReadKey(true);

                // Check the current keypress against the stored keypress
                if (cki.Key == ConsoleKey.X)
                {
                    end = true;
                }

                if ((cki.Key != ConsoleKey.X) && (end != true))
                {
                    ConsoleGameMenu.Program.DeleteChar();
                }

                if(cki.Key == ConsoleKey.Spacebar)
                {
                    //board.player.Shoot();
                }

                if ((cki.Key == ConsoleKey.W) || (cki.Key == ConsoleKey.A) || (cki.Key == ConsoleKey.S) || (cki.Key == ConsoleKey.D))
                {
                    board.MovePlayer(char.ToLower(cki.KeyChar));
                    ConsoleGameMenu.Program.ResetConsoleColor();
                }
                
                // set cursor position to the end of terminal
                ConsoleGameMenu.Program.SetCursorPosition(Console.BufferWidth - 1, Console.BufferHeight - 1);

            } while (end != true);
        }
    }
}
