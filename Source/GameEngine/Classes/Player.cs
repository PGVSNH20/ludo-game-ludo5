using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Player
    {
        public string Name { get; set; }
        public bool PiecesLeft { get; set; }
        public List<Piece> Pieces { get; set; }
        public ColorType Color { get; set; }
    }
}
