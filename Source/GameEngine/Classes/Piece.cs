using GameEngine.Enumerations;
using System;
using System.Collections.Generic;

namespace GameEngine.Classes
{
    public class Piece
    {
        public int HiddenID { get; set; }   // Unique ID for engine to keep pieces separate
        public int PublicID { get; set; }   // Public ID for the player to use when choosing which to move
        public int PlayerID { get; set; }
        public int PiecePosition { get; set; } // -1 nest, -2 goal
        private static int incrementedId { get; set; } = 0;

        public Piece(int pubId, int playId)
        {
            HiddenID = incrementedId;
            PublicID = pubId;
            PlayerID = playId;
            PiecePosition = -1;
            incrementedId++;
        }
        public static List<Piece> GeneratePieces(int players)
        {
            List<Piece> pieces = new();
            for (int j = 0; j < players; j++)       // For each player
            {
                for (int k = 0; k < 4; k++)         // Four per player
                {
                    pieces.Add(new Piece(k, j));
                }
            }
            incrementedId = 0;
            return pieces;
        }
    }
}
