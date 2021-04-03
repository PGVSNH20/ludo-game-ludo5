using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Gamestate
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public List<Turn> Turnlist { get; set; }

        public Gamestate(Board board, int players)
        {
            Board = board;
            Players = GeneratePlayers(players);
            Turnlist = new List<Turn>();
        }

        private List<Player> GeneratePlayers(int players)
        {
            throw new NotImplementedException();
        }

        public Gamestate AddTurn()
        {
            Turnlist.Add(new Turn());
            return this;
        }
    }
}
