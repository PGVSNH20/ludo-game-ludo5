using System;
using System.ComponentModel.DataAnnotations.Schema;
using GameEngine.Dice;
using GameEngine.Interfaces;

namespace GameEngine
{
    [NotMapped]
    public class AIDice : BaseDice
    {
        public override int Roll()
        {
            return new Random().Next(1, 7);
        }

        public int Roll(int size)
        {
            return new Random().Next(1, size+1);
        }
    }
}
