using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    class GameSettings
    {
        public int Players { get; set; }
        public int BoardSize { get; set; }
        //choose how many players and they write in their names
        public GameSettings(int players, int boardSize)
        {
            Players = players;
            BoardSize = boardSize;
        }
    }
}
