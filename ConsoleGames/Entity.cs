using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGames
{
    internal class Entity
    {
        public char symbol;

        public Entity()
        {
            symbol = ' ';
        }

        public Entity(char symbol)
        {
            this.symbol = symbol;
        }
    }
}
