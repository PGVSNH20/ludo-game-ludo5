using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class Dice
    {
        public static int Roll()
        {
            return new Random().Next(1, 7);
        }

        public static int Roll(int size)
        {
            return new Random().Next(1, size-1);
        }
    }
}
