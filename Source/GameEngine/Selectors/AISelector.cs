using GameEngine.Models;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Selectors
{
    [NotMapped]
    public class AISelector : ISelector
    {

        public Turn Selector(Gamestate state,Turn currentTurn, List<int> selectionList)
        {
            currentTurn.PieceID = selectionList[0];

            //if currentturn.roll == 6
            //if piece postion == -1.


            return currentTurn;
        }


        public bool KnockOut(int pieceId, Turn currentturn, Board board)
        {
            int LandingSpot = board.Pieces[pieceId].PiecePosition + (int)currentturn.Roll;

            if (!board.MainBoard[LandingSpot].Safe)
            {
                foreach (Piece item in board.Pieces)
                {
                    if (LandingSpot == item.PiecePosition && item.PlayerID != board.Pieces[pieceId].PlayerID)
                    {
                        return true;
                    }
                }
            }


        return false; 

        }

        public bool LeaveNest(int pieceId, Turn currentturn, Board board)
        {
            


            return false;

        }





        ///1 Move out of nest.
        ///2 Knock away oponents piece.
        ///3 Move to Goal.
        ///4 Move random piece. 
    }
}
