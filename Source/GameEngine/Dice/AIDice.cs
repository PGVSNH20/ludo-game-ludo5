using System;
using GameEngine.Interfaces;

namespace GameEngine
{
    public class AIDice : IDice
    {
        public int Roll()
        {
            return new Random().Next(1, 7);
        }

        public int Roll(int size)
        {
            return new Random().Next(1, size+1);
        }
    }
}
