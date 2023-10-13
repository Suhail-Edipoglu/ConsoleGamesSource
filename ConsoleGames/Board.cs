using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleGames
{
    internal class Board
    {
        readonly int height = 25;
        readonly int width = 115;
        public List<List<Entity>> field = new List<List<Entity>>();
        public List<List<Entity>> entities = new List<List<Entity>>();
        public Player? player;

        public void PrintBoard()
        {
            int counter = 0;

            if(field.Count == 0 || entities.Count == 0)
            {
                return;
            }

            for (int i = 0; i < height; i++)
            {
                counter++;
                counter++;
                for (int j = 0; j < width; j++)
                {
                    if ((counter % 2 == 0) && (field[i][j].symbol != ' '))
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGreen, ConsoleColor.Red);
                    }

                    if (entities[i][j].symbol == 'P')
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Red);
                        Console.Write(entities[i][j].symbol);
                        ConsoleGameMenu.Program.ResetConsoleColor();
                    }
                    else if (entities[i][j].symbol == '#')
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkBlue, ConsoleColor.Red);
                        Console.Write(entities[i][j].symbol);
                        ConsoleGameMenu.Program.ResetConsoleColor();
                    }
                    else if (entities[i][j].symbol == '>')
                    {
                        ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkYellow, ConsoleColor.Blue);
                        Console.Write(entities[i][j].symbol);
                        ConsoleGameMenu.Program.ResetConsoleColor();
                    }
                    else
                    {
                        Console.Write(field[i][j].symbol);
                    }

                    ConsoleGameMenu.Program.ResetConsoleColor();

                    counter++;
                }
                Console.WriteLine();
            }
        }

        public void GenerateMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Entity entity = new Entity();
                    if (i == 0 && j == 0)
                    {
                        entity.symbol = '/';
                    }
                    else if (i == 0 && j == (width - 1))
                    {
                        entity.symbol = '\\';
                    }
                    else if (i == (height - 1) && j == (width - 1))
                    {
                        entity.symbol = '/';
                    }
                    else if (i == (height - 1) && j == 0)
                    {
                        entity.symbol = '\\';
                    }
                    else if ((i == 0 || i == (height - 1)) && (j > 0 && j < width))
                    {
                        entity.symbol = '-';
                    }
                    else if ((i > 0 && i < height) && (j == 0 || j == (width - 1)))
                    {
                        entity.symbol = '|';
                    }
                    else
                    {
                        entity.symbol = ' ';
                    }
                    if (field.Count <= i)
                    {
                        field.Add(new List<Entity>());
                    }
                    field[i].Insert(j, entity);
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        Player player = new Player(j, i, 'P');

                        if (entities.Count <= i)
                        {
                            entities.Add(new List<Entity>());
                        }
                        entities[player.y].Insert(player.x, player);
                        this.player = player;
                    }
                    else if (((i > 9) && (i < 13) && (j > 30) && (j < width - 30)) && ((i != 11) && (j > 30) && (j < width - 30)))
                    {
                        Block block = new Block(j, i, '#');

                        if (entities.Count <= i)
                        {
                            entities.Add(new List<Entity>());
                        }
                        entities[block.y].Insert(block.x, block);
                    }
                    else if ((i == 19) && (j == 13))
                    {
                        Arrow arrow = new Arrow(j, i, '>');

                        if (entities.Count <= i)
                        {
                            entities.Add(new List<Entity>());
                        }
                        entities[arrow.y].Insert(arrow.x, arrow);
                    }
                    else
                    {
                        Entity entity = new Entity();
                        entity.symbol = ' ';

                        if (entities.Count <= i)
                        {
                            entities.Add(new List<Entity>());
                        }
                        entities[i].Insert(j, entity);
                    }
                }
            }
        }

        public void MovePlayer(char input)
        {
            int heightDeleteChar = -1;
            int widthDeleteChar = -1;

            Player player = new Player();
            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = 0; j < entities[i].Count; j++)
                {
                    if (entities[i][j].symbol == 'P')
                    {
                        if (CheckIfFree(input, i, j) == true)
                        {
                            player = (Player)entities[i][j];
                            heightDeleteChar = j;
                            widthDeleteChar = i;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            ConsoleGameMenu.Program.ResetConsoleColor();

            if (heightDeleteChar != -1 && widthDeleteChar != -1)
            {
                switch (input)
                {
                    case 'w':
                        if (player.y > 0)
                        {
                            player.y--;
                            ConsoleGameMenu.Program.SetCursorPosition(heightDeleteChar, widthDeleteChar);
                            Console.Write(' ');
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Red);
                            ConsoleGameMenu.Program.SetCursorPosition(player.x, player.y);
                            Console.Write(player.symbol);
                        }
                        break;
                    case 'a':
                        if (player.x > 0)
                        {
                            player.x--;
                            ConsoleGameMenu.Program.SetCursorPosition(heightDeleteChar, widthDeleteChar);
                            Console.Write(' ');
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Red);
                            ConsoleGameMenu.Program.SetCursorPosition(player.x, player.y);
                            Console.Write(player.symbol);
                        }
                        break;
                    case 's':
                        if (player.y < (height - 1))
                        {
                            player.y++;
                            ConsoleGameMenu.Program.SetCursorPosition(heightDeleteChar, widthDeleteChar);
                            Console.Write(' ');
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Red);
                            ConsoleGameMenu.Program.SetCursorPosition(player.x, player.y);
                            Console.Write(player.symbol);
                        }
                        break;
                    case 'd':
                        if (player.x < (width - 1))
                        {
                            player.x++;
                            ConsoleGameMenu.Program.SetCursorPosition(heightDeleteChar, widthDeleteChar);
                            Console.Write(' ');
                            ConsoleGameMenu.Program.SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Red);
                            ConsoleGameMenu.Program.SetCursorPosition(player.x, player.y);
                            Console.Write(player.symbol);
                        }
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = 0; j < entities[i].Count; j++)
                {
                    if (entities[i][j].symbol == 'P')
                    {
                        entities[i][j] = new Entity();
                        entities[i][j].symbol = ' ';
                    }
                }
            }

            entities[player.y][player.x] = player;
        }

        public bool CheckIfFree(char input, int x, int y)
        {
            switch (input)
            {
                case 'w':
                    if(x == 0)
                    {
                        return false;
                    }
                    if ((field[x - 1][y].symbol == ' ') && (entities[x - 1][y].symbol == ' '))
                    {
                        return true;
                    }
                    break;
                case 'a':
                    if(y == 0)
                    {
                        return false;
                    }
                    if ((field[x][y - 1].symbol == ' ') && (entities[x][y - 1].symbol == ' '))
                    {
                        return true;
                    }
                    break;
                case 's':
                    if(x == (height - 1))
                    {
                        return false;
                    }
                    if ((field[x + 1][y].symbol == ' ') && (entities[x + 1][y].symbol == ' '))
                    {
                        return true;
                    }
                    break;
                case 'd':
                    if(y == (width - 1))
                    {
                        return false;
                    }
                    if ((field[x][y + 1].symbol == ' ') && (entities[x][y + 1].symbol == ' '))
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        public void GenerateMap(string mapFileName)
        {
            field = new List<List<Entity>>();
            entities = new List<List<Entity>>();
            XDocument doc = XDocument.Load(mapFileName);

            // read the 'Map' node
            var mapElement = doc.Element("Map");

            if (mapElement != null)
            {
                var fieldElements = mapElement.Element("field");

                // create 2d list of field entities with symbol ' '
                for (int i = 0; i < height; i++)
                {
                    field.Add(new List<Entity>());
                    for (int j = 0; j < width; j++)
                    {
                        Entity entity = new Entity();
                        entity.symbol = ' ';
                        field[i].Insert(j, entity);
                    }
                }

                if (fieldElements != null)
                {
                    var fieldEntities = fieldElements.Elements("Entity");

                    foreach (var fieldEntity in fieldEntities)
                    {
                        char symbol = char.Parse(fieldEntity.Element("symbol").Value);
                        int x = int.Parse(fieldEntity.Element("x").Value);
                        int y = int.Parse(fieldEntity.Element("y").Value);

                        Entity entity = new Entity(symbol);

                        field[y].Insert(x, entity);
                    }
                }

                var EntitiesElements = mapElement.Element("entities");

                // create 2d list of entities with symbol ' '
                for (int i = 0; i < height; i++)
                {
                    entities.Add(new List<Entity>());
                    for (int j = 0; j < width; j++)
                    {
                        Entity entity = new Entity();
                        entity.symbol = ' ';
                        entities[i].Insert(j, entity);
                    }
                }

                if (EntitiesElements != null)
                {
                    var entitiesEntities = EntitiesElements.Elements();

                    foreach (var entitiesEntity in entitiesEntities)
                    {
                        char symbol = char.Parse(entitiesEntity.Element("symbol").Value);
                        int x = int.Parse(entitiesEntity.Element("x").Value);
                        int y = int.Parse(entitiesEntity.Element("y").Value);

                        if(symbol == 'P')
                        {
                            Player player = new Player(x, y, symbol);
                            entities[y].Insert(x, player);
                            this.player = player;
                        }
                        else if(symbol == '#')
                        {
                            Block block = new Block(x, y, symbol);
                            entities[y].Insert(x, block);
                        }
                        else if(symbol == '>')
                        {
                            Arrow arrow = new Arrow(x, y, symbol);
                            entities[y].Insert(x, arrow);
                        }
                        else
                        {
                            Entity entity = new Entity(symbol);
                            entities[y].Insert(x, entity);
                        }

                    }
                }
            }


        }

    }

}
