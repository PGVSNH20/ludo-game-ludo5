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
        public int ActivePlayer { get; set; }
        public List<Player> PlayersStillPlaying { get; set; }

        public Gamestate(GameSettings settings)
        {
            Board = new Board(settings.Players, settings.BoardSize);
            Players = Player.GeneratePlayers(settings.Players);
            Turnlist = new List<Turn>();
            Settings = settings;
            ActivePlayer = 0;
            PlayersStillPlaying = GetAllPlayers();
        }


        public Gamestate AddTurn()
        {
            Turnlist.Add(new Turn());
            return this;
        }

        private List<Player> GetAllPlayers()
        {
            List<Player> allPlayers = new List<Player>();
            foreach (Player p in Players)
            {
                allPlayers.Add(p);
            }
            return allPlayers;
        }
    }
}
