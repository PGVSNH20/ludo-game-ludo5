using System.Collections.Generic;

namespace GameEngine.Models
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
