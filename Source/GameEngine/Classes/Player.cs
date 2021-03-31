using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class Player
    {
        public string Name { get; set; }
        public int PiecesAtNest { get; set; }
        public int PiecesFinished { get; set; }
        public List<Piece> Pieces { get; set; }
        public Nest Nest { get; set; }
        public int SelectedPiece { get; set; }
        public ColorType Color { get; set; }
    }
}
