using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Models
{
    public class GameSettings
    {
        public int Id { get; set; }
        public List<PlayerSetting> Players { get; set; }
        public int BoardSize { get; set; }
        //choose how many players and they write in their names
        public GameSettings(List<PlayerSetting> players)
        {
            Players = players;
            BoardSize = 10 * (Players.Count);
        }
        public GameSettings(List<PlayerSetting> players, int boardSize)
        {
            Players = players;
            BoardSize = boardSize;
        }
        public GameSettings()
        {

        }
    }
}
