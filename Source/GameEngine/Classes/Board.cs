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
        public List<Square> Nests {get; set;}

        public List<int> StartingPositions;
        public List<Piece> Pieces { get; set; }

        
        
        //Dymaic generation.

        public Board(int players, int spaces)
        {
            MainBoard = new List<Square>();
            for (int i = 0; i < spaces; i++)
            {
                MainBoard.Add(new Square(i));
            }

            CreateHomeStretches(players);
            StartingPositions = generateStartPosistions(players,spaces);




        }


        public void CreateHomeStretches(int players)
        {
            HomeStretches = new List<List<Square>>();
            //set up homestreches
            for (int p = 0; p < 4; p++)
            {
                HomeStretches.Add(new List<Square>());
            }

            foreach (var colorList in HomeStretches)
            {
                for (int z = 0; z < 5; z++)
                {
                    colorList.Add(new Square(z));
                }
            }

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
    }
}
