using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Dice
{
    class ConsoleDice : IDice
    {
        public int Roll()
        {
            Console.WriteLine("Press Enter to roll the dice");
            Console.ReadLine();
            var roll = new Random();
            return roll.Next(1, 7);
        }
    }
}
