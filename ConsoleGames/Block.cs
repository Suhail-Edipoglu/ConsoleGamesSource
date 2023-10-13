using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGames
{
    internal class Block : Entity
    {
        public int x;
        public int y;

        public Block()
        {
            x = 10;
            y = 10;
            symbol = '#';
        }

        public Block(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
    }
}
