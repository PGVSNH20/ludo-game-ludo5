using GameEngine.Models;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GameEngine.EngineFunctionality;

namespace GameEngine.Selectors
{
    [NotMapped]
    public class AISelector : ISelector
    {
        public Turn Selector(Gamestate state, Turn currentTurn, List<int> selectionList)
        {
            int roll = (int)currentTurn.Roll;
            Board board = state.Board;
            Random random = new();

            List<int> leaveList = LeaveNest(selectionList, roll, board);
            if (leaveList.Count > 0)
            {
                currentTurn.PieceID = selectionList[random.Next(0, leaveList.Count)];
                return currentTurn;
            }

            List<int> knockList = KnockOut(selectionList, roll, board);
            if (knockList.Count > 0)
            {
                currentTurn.PieceID = selectionList[random.Next(0, knockList.Count)];
                return currentTurn;
            }

            List<int> homeList = EnterHomeStrech(selectionList, roll, board);
            if (homeList.Count > 0)
            {
                currentTurn.PieceID = selectionList[random.Next(0, homeList.Count)];
                return currentTurn;
            }

            currentTurn.PieceID = selectionList[random.Next(0, selectionList.Count)];

            return currentTurn;

        }


        public List<int> KnockOut(List<int> selections, int roll, Board board)
        {
            List<int> results = new();

            foreach (var pieceId in selections)
            {
                int LandingSpot = Movement.PiecePositionCalculator(roll, pieceId, board.Pieces[pieceId].PiecePosition, board.MainBoard.Count);

                if (!board.MainBoard[LandingSpot].Safe)
                {
                    foreach (Piece item in board.Pieces)
                    {
                        if (LandingSpot == item.PiecePosition && item.PlayerID != board.Pieces[pieceId].PlayerID)
                        {
                            results.Add(pieceId);
                        }
                    }
                }



            }
            return results;

        }

        public List<int> LeaveNest(List<int> selections, int roll, Board board)
        {
            List<int> results = new();

            foreach (var pieceId in selections)
            {
                if (roll == 6 && board.Pieces[pieceId].PiecePosition == -1)
                {
                    results.Add(pieceId);
                }
            }

            return results;
        }


        public List<int> EnterHomeStrech(List<int> selections, int roll, Board board)
        {
            List<int> results = new();
            foreach (var pieceId in selections)
            {
                int LandingSpot = Movement.PiecePositionCalculator(roll, pieceId, board.Pieces[pieceId].PiecePosition, board.MainBoard.Count);

                if (LandingSpot > board.MainBoard.Count || LandingSpot == -2)
                {
                    results.Add(pieceId);
                }
            }

            return results;
        }





        ///1 Move out of nest.
        ///2 Knock away oponents piece.
        ///3 Move to HomeStretch /Goal
        ///4 Move random piece. 
    }
}
