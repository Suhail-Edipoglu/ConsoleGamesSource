using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGames
{
    internal class Player : Entity
    {
        public int x;
        public int y;

        public Player()
        {
            x = 1;
            y = 1;
            symbol = 'P';
        }

        public Player(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        /*public void Shoot(char direction)
        {
            switch (direction)
            {
                case 'w':
                    if (x == 0)
                    {
                        break;
                    }
                    else
                    {
                        Arrow arrow = new Arrow(x - 1, y, '↑');
                        break;
                    }
            }
        }*/
    }
}
