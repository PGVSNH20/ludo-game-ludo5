using GameEngine.Models;
using System.Collections.Generic;

namespace GameEngine.EngineFunctionality
{
    public static class PlayerFunctions
    {
        public static bool CheckIfActivePlayerIsInTheGame(Gamestate state)
        {
            foreach (Player p in state.PlayersStillPlaying)
            {
                if (state.ActivePlayer == p.Id) return true;
            }
            return false;
        }

        public static bool CheckIfActivePlayerHasWon(Gamestate state)
        {
            List<Piece> pieces = GetActivePlayersPieces(state);
            foreach (Piece p in pieces)
            {
                if (p.PiecePosition != -2) return false;
            }
            return true;
        }
        public static List<Piece> GetActivePlayersPieces(Gamestate state)
        {
            List<Piece> activePlayerPieces = new List<Piece>();
            foreach (Piece p in state.Board.Pieces)
            {
                if (p.PlayerID == state.ActivePlayer) activePlayerPieces.Add(p);
            }
            return activePlayerPieces;
        }
    }
}
