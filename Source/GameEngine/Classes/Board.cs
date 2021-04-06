using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Board
    {

        //Standard board is 48 spaces long, + the home stretches.

        public List<Square> MainBoard { get; set; } = new();
        public List<Square> HomeStretch { get; set; } = new();

        public List<int> StartingPositions;
        public List<Piece> Pieces { get; set; } = new();

        public Board(int players, int spaces)
        {
            int GoalStretch = 5;
            int i = 0;
            for (; i < spaces; i++)
            {
                MainBoard.Add(new Square(i));
            }
            for (; i < spaces+GoalStretch; i++)
            {
                HomeStretch.Add(new Square(i));
            }

            StartingPositions = generateStartPosistions(players,spaces);

            for (int j = 0; j < players; j++)       // For each player
            {
                for (int k = 0; k < 4; k++)         // Four per player
                {
                    Pieces.Add(new Piece(k, j));
                }
            }
        
        }


        //variable size
        public Board(int players)
        {

            int spaces = (players * 11) + players;
            MainBoard = new List<Square>();
            int GoalStretch = 5;

            for (int i = 0; i < spaces + GoalStretch; i++)
            {
                MainBoard.Add(new Square(i));
            }

            StartingPositions = generateStartPosistions(players, spaces);


        }

        private List<int> generateStartPosistions(int players, int Boardsize)
        {
            List<int> startPositions = new List<int>();
            for (int i = 0; i < Boardsize; i+=10)
            {
                startPositions.Add(i);
            }

            return startPositions;

        }

        public void createPieces()
        {

        }
    }
}
