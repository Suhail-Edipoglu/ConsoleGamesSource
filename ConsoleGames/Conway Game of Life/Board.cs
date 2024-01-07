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
        public List<List<int>> boardlist = new List<List<int>>();

        public Board()
        {
            height = 25;
            width = 115;
        }

        public void GenerateRandomBoard()
        {
            Random random = new Random();
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(random.Next(0, 2));
                }
                boardlist.Add(row);
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Conway's Game of Life");
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
                        Console.Write(boardlist[i][j]);
                    }
                    else
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.White, ConsoleColor.White);
                        Console.Write(boardlist[i][j]);
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
                        if (boardlist[i - 1][i - 1] == 1)
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
            Console.ReadLine();
        }
    }
}
