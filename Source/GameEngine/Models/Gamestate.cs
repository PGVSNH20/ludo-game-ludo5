using System.Collections.Generic;

namespace GameEngine.Models
{
    public class Gamestate
    {
        public GameSettings Settings { get; }
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public List<Turn> Turnlist { get; set; }
        public int ActivePlayer { get; set; }
        public List<Player> PlayersStillPlaying { get; set; }
        public bool GameHasNoWinner { get; set; }

        public Gamestate(GameSettings settings)
        {
            Board = new Board(settings.Players.Count, settings.BoardSize);
            Players = Player.GeneratePlayers(settings.Players);
            Turnlist = new List<Turn>();
            Settings = settings;
            ActivePlayer = 0;
            PlayersStillPlaying = GetAllPlayers();
        }
        public Gamestate() { }

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
