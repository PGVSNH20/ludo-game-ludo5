using GameEngine.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Dice
{
    [NotMapped]
    public class ConsoleDice : IDice
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
