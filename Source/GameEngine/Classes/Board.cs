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
       
        public List<Square> MainBoard{ get; set; }
        public List<Square> HomeStretch { get; set; }

        public List<int> StartingPositions;
        public List<Piece> Pieces { get; set; }

        public Board(int players, int spaces)
        {
            MainBoard = new List<Square>();
            int GoalStretch = 5;
            int i = 0;
            for (; i < spaces; i++)
            {
                MainBoard.Add(new Square(i));
            }
            
            HomeStretch = new List<Square>();
            for (; i < spaces+GoalStretch; i++)
            {
                HomeStretch.Add(new Square(i));
            }

            StartingPositions = generateStartPosistions(players,spaces);
        
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
