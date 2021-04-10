
using GameEngine.Dice;
using GameEngine.Interfaces;
using GameEngine.Selectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class PlayerSetting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public BaseDice Dice { get; set; }
        public BaseSelector Selector { get; set; }
        public PlayerSetting (string name, BaseDice dice, BaseSelector selector)
        {
            Name = name;
            Dice = dice;
            Selector = selector;
        }
        public PlayerSetting()
        {

        }
    }
}
