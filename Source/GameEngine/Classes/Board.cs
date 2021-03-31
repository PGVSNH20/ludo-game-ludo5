using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Board
    {
        
        //Spelare läggs i ordning i listor, den första indexen i en lista motsvar första spelaren.

        int[] StartPositions = { 1, 2, 3, 4 };

        public List<Square> MainBoard{ get; set; }

        public List<List<Square>> HomeStretches { get; set; }

        public List<Square> Nests {get; set;}

        //Dymaic generation.

        public Board(int players, int spaces)
        {
            
            int i = 0;
            for (; i < spaces; i++)
            {
                MainBoard.Add(new Square(i));
            }

            CreateHomeStretches(players);
        }


        public void CreateHomeStretches(int players)
        {

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

        



    }
}
