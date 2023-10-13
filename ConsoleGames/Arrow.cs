using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGames
{
    internal class Arrow : Entity
    {
        public int x;
        public int y;

        public Arrow()
        {
            x = 10;
            y = 10;
            symbol = '>';
        }

        public Arrow(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
    }
}
