﻿using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class GameSettings
    {
        public List<string> Players { get; set; }
        public int BoardSize { get; set; }
        //choose how many players and they write in their names
        public GameSettings(List<string> players)
        {
            Players = players;
            BoardSize = 10*(Players.Count);
        }
    }
}
