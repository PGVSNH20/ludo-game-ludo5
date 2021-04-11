using GameEngine.Interfaces;

namespace GameEngine.Models
{
    public class PlayerSetting
    {
        public int Id { get; set; }
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
