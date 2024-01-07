using System;

namespace Conway
{
	public class GameOfLife
	{
		public GameOfLife()
		{
		}

		public void Run()
		{
            Board board = new Board();

			board.GenerateRandomBoard();
            Console.Clear();
            board.PrintBoard();
			board.UpdateBoard();
        }
	}
}