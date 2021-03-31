using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Square
    {
        public int Id { get; }
        public List<Piece> Pieces { get; set; }
        public int Safe { get; }
        //safe for player #x

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
