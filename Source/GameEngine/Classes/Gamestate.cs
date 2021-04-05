using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Gamestate
    {
        public GameSettings Settings { get; }
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public List<Turn> Turnlist { get; set; }

        public Gamestate(GameSettings settings)
        {
            Board = new Board(settings.Players, settings.BoardSize);
            Players = Player.GeneratePlayers(settings.Players);
            Turnlist = new List<Turn>();
            Settings = settings;
        }


        public Gamestate AddTurn()
        {
            Turnlist.Add(new Turn());
            return this;
        }
    }
}
