using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Board
    {

        //Spelare läggs i ordning i listor, den första indexen i en lista motsvar första spelaren.


        public List<Square> MainBoard{ get; set; }
        public List<List<Square>> HomeStretches { get; set; }

        public List<int> StartingPositions;
        public List<Piece> Pieces { get; set; }

        
        
        //Dymaic generation.

        public Board(int players, int spaces)
        {
            MainBoard = new List<Square>();
            int GoalStretch = 5;

            for (int i = 0; i < spaces+GoalStretch; i++)
            {
                MainBoard.Add(new Square(i));
            }

            StartingPositions = generateStartPosistions(players,spaces);
        
        }

        private List<int> generateStartPosistions(int players, int Boardsize)
        {
            List<int> startPositions = new List<int>();

            int x = Boardsize / players;

            for (int i = 0; i < Boardsize; i += (Boardsize / 40))
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
