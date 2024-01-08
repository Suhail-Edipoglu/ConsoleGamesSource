using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conway
{
	public class GameOfLife
	{
        public bool end = false;

        public GameOfLife()
		{
		}

		public void Run()
		{
            Board board = new Board();

			board.GenerateRandomBoard();
            ConsoleGameMenu.Program.Clear();
            ConsoleGameMenu.Program.HideCursor();
            board.PrintBoard();
			Sleep(2000);

            do
			{
                Sleep(100);
                //ConsoleGameMenu.Program.Clear();
				board.generation++;
                board.UpdateBoard();
				//board.PrintBoard();
            } while (end != true);
        }

		public void Sleep(int millisecs)
		{
            System.Threading.Thread.Sleep(millisecs);
        }
	}
}