using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Piece
    {
        public ColorType Color { get; set; }
        public int PieceID { get; set; }
        public bool IsAtNest { get; set; }
        public int PiecePosition { get; set; }
        public bool PieceFinieshed { get; set; }
        public bool PieceInFinishLine { get; set; }

    }
}
