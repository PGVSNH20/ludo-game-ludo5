using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Square
    {
        int Id;
        List<Piece> Pieces;
        int Safe;
        //safe  for player #x



        public Square(int id)
        {
            Id = id;
            Safe = -1;
        }


        public Square(int id, int safe)
        {
            Id = id;
            Safe = safe;
        }





    }
}
