using GameEngine.Enumerations;
using System;


namespace GameEngine.Classes
{
    public class Piece
    {
        public ColorType Color { get; set; }
        public int PieceID { get; set; }
        public bool IsAtNest { get; set; }
        public int PiecePosition { get; set; }
        public bool PieceFinished { get; set; }
        public bool PieceInFinishLine { get; set; }
    }
}
