using GameEngine.Enumerations;
using System;


namespace GameEngine.Classes
{
    public class Piece
    {
        public int HiddenID { get; set; }   // Unique ID for engine to keep pieces separate
        public int PublicID { get; set; }   // Public ID for the player to use when choosing which to move
        public int PlayerID { get; set; }
        public int PiecePosition { get; set; } // -1 nest, -2 goal
    }
}
