using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Dice
{
    [NotMapped]
    public class ConsoleDice : BaseDice
    {
        public override int Roll()
        {
            Console.WriteLine("Press Enter to roll the dice");
            Console.ReadLine();
            var roll = new Random();
            return roll.Next(1, 7);
        }
    }
}
