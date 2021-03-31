using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Board
    {

        

        public List<Square> MainSpace;

        //En Lista av listor? lägg till färg dynamiskt?

        List<List<Square>> colors;
        
        public List<Square> Red;
        public List<Square> Blue;
        public List<Square> Yellow;
        public List<Square> Green;

        
        //Standard Board.
        public Board()
        {
            int i = 0;  
            for (; i < 48; i++)
            {
                MainSpace.Add(new Square(i,0));
            }

            for (int z = 0; z < 5; z++)
            {
                Red.Add(new Square(i++,0));
                Blue.Add(new Square(i++, 0));
                Yellow.Add(new Square(i++, 0));
                Green.Add(new Square(i++, 0));
            }
        }


        //Dymaic generation.
        public Board(int players, int spaces)
        {

            for (int p = 0; p < players; p++)
            {
                colors.Add(new List<Square>());
            }

            int i = 0;
            for (; i < spaces; i++)
            {
                MainSpace.Add(new Square(i,0));
            }

            foreach (var colorList in colors)
            {
                for (int z = 0; z < 5; z++)
                {
                    colorList.Add(new Square(i++));
                }
            }




        }


        private Square makeNewSquare(int id)
        {
            ///if that number then safe, to be implemented.
            ///
            return new Square(id, 0);
        }



    }
}
