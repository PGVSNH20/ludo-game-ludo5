using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Square
    {
        public int Id { get; }
        public List<int> PieceID { get; set; }
        public bool Safe { get; }
        //safe for player #x

        public Square(int id)
        {
            Id = id;
            Safe = false;
        }

        public Square(int id, bool safe)
        {
            Id = id;
            Safe = safe;
        }
    }
}
