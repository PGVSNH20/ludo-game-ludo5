using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Piece> Pieces { get; set; }
        public ColorType Color { get; set; }
        public Player(int i)
        {
           
        }
    }
}
