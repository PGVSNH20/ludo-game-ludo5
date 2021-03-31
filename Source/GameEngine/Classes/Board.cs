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

        //List<List<Square>> colors;
        
        public List<Square> Red;
        public List<Square> Blue;
        public List<Square> Yellow;
        public List<Square> Green;

        
        //Standard Board.
        public Board()
        {
            for (int i = 0; i < 48; i++)
            {
                MainSpace.Add(new Square());
            }

            for (int i = 0; i < 5; i++)
            {
                Red.Add(new Square());
                Blue.Add(new Square());
                Yellow.Add(new Square());
                Green.Add(new Square());
            }
        }


        //Make Big board,5+ players
        public Board(int players, int spaces)
        {
            




        }



    }
}
