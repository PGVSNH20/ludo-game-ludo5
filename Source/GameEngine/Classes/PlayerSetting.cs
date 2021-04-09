
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class PlayerSetting
    {
        public string Name { get; set; }
        public IDice Dice { get; set; }
        public ISelector Selector { get; set; }
        public PlayerSetting (string name, IDice dice, ISelector selector)
        {
            Name = name;
            Dice = dice;
            Selector = selector;
        }
    }
}
