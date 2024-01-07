using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleGames
{
    internal class Enemy : Entity
    {
        public int x;
        public int y;

        public Enemy()
        {
            x = 100;
            y = 20;
            symbol = '!';
        }

        public Enemy(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        public void FollowPlayer(Player player)
        {
            if (player.x > x)
            {
                x++;
            }
            else if (player.x < x)
            {
                x--;
            }
            else if (player.y > y)
            {
                y++;
            }
            else if (player.y < y)
            {
                y--;
            }
        }

        public void MoveRandomly(Board board)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);

            switch (randomNumber)
            {
                case 0:
                    if (board.CheckIfFree('w', this.x, this.y))
                    {
                        x--;
                    }
                    break;
                case 1:
                    if (board.CheckIfFree('s', this.x, this.y))
                    {
                        x++;
                    }
                    break;
                case 2:
                    if (board.CheckIfFree('d', this.x, this.y))
                    {
                        y++;
                    }
                    break;
                case 3:
                    if (board.CheckIfFree('a', this.x, this.y))
                    {
                        y--;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
