using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Board
    {

        public List<Square> MainSpace { get; set; }

        //En Lista av listor? lägg till färg dynamiskt?
        public List<List<Square>> Colors { get; set; }

        public List<Square> Red { get; set; }
        public List<Square> Blue { get; set; }
        public List<Square> Yellow { get; set; }
        public List<Square> Green { get; set; }


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
                Colors.Add(new List<Square>());
            }

            int i = 0;
            for (; i < spaces; i++)
            {
                MainSpace.Add(new Square(i,0));
            }

            foreach (var colorList in Colors)
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
