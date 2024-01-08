using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    internal class Board
    {
        public int height;
        public int width;
        public int generation = 0;
        public List<List<int>> boardlist = new List<List<int>>();
        public List<List<int>> oldboardlist = new List<List<int>>();

        public Board()
        {
            height = 25;
            width = 115;

            // initialize boardlist and oldboardlist with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                boardlist.Add(row);
                oldboardlist.Add(row);
            }
        }

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;

            // initialize boardlist and oldboardlist with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                boardlist.Add(row);
                oldboardlist.Add(row);
            }
        }

        public void GenerateRandomBoard()
        {
            Random random = new Random();
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    // 1 has a 33.33% chance of being generated
                    if (random.Next(0, 3) == 1)
                    {
                        boardlist[i][j] = 1;
                    }
                    else
                    {
                        boardlist[i][j] = 0;
                    }
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("Welcome to Conway's Game of Life, Generation: " + generation);
            ConsoleGameMenu.Program.ResetConsoleColor();
            for (int i = 0; i < height; i++)
            {
                ConsoleGameMenu.Program.ResetConsoleColor();
                for (int j = 0; j < width; j++)
                {
                    ConsoleGameMenu.Program.ResetConsoleColor();
                    if (boardlist[i][j] == 0)
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.Black, ConsoleColor.Black);
                        Console.Write(" ");
                    }
                    else
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.White, ConsoleColor.White);
                        Console.Write(" ");
                    }
                }
                ConsoleGameMenu.Program.ResetConsoleColor();
                Console.WriteLine();
            }
        }

        public void UpdateBoard()
        {
            int neighbours;
            List<List<int>> newBoard = new List<List<int>>();
            List<List<int>> neighbourcount = new List<List<int>>();

            // fill neighbourcount list with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                neighbourcount.Add(row);
            }

            // fill newBoard with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                newBoard.Add(row);
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    neighbours = 0;
                    if ((i == 0) && (j == 0))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j == 0))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j == (width - 1)))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == 0) && (j == (width - 1)))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i != 0) && (i != (height - 1)) && (j == 0))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j != 0) && (j != (width - 1)))
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i != 0) && (i != (height - 1)) && (j == (width - 1)))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == 0) && (j != 0) && (j != (width - 1)))
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((boardlist[i][j] == 0) && (neighbourcount[i][j] == 3))
                    {
                        newBoard[i][j] = 1;
                    }
                    else if ((boardlist[i][j] == 1) && (neighbourcount[i][j] < 2))
                    {
                        newBoard[i][j] = 0;
                    }
                    else if ((boardlist[i][j] == 1) && ((neighbourcount[i][j] == 2) || (neighbourcount[i][j] == 3)))
                    {
                        newBoard[i][j] = 1;
                    }
                    else if ((boardlist[i][j] == 1) && (neighbourcount[i][j] > 3))
                    {
                        newBoard[i][j] = 0;
                    }
                    else
                    {
                        newBoard[i][j] = boardlist[i][j];
                    }

                    ConsoleGameMenu.Program.SetCursorPosition(46, 0);
                    Console.Write(generation);

                    if (boardlist[i][j] != newBoard[i][j])
                    {
                        ConsoleGameMenu.Program.ResetConsoleColor();
                        if (newBoard[i][j] == 0)
                        {
                            ConsoleGameMenu.Program.SetCursorPosition(j, i + 1);
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.Black, ConsoleColor.Black);
                            Console.Write(" ");
                        }
                        else
                        {
                            ConsoleGameMenu.Program.SetCursorPosition(j, i + 1);
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.White, ConsoleColor.White);
                            Console.Write(" ");
                        }
                        ConsoleGameMenu.Program.ResetConsoleColor();
                    }

                    // set cursor position to the end of terminal
                    ConsoleGameMenu.Program.SetCursorPosition(Console.BufferWidth - 1, Console.BufferHeight - 1);
                }
            }

            // replace boardlist with newboard and clear newboard
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    oldboardlist[i][j] = boardlist[i][j];
                    boardlist[i][j] = newBoard[i][j];
                }
            }
        }
    }
}
