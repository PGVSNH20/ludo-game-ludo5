﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using System.Collections.Generic;

namespace GameEngineTests
{
    class PlayerFunctionsTests
    {

        [Test]
        public void NoActivePlayersNoActivePieces()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));

            for (int x = 0; x < state.Players.Count; x++)
            {
                state.Players[x].FinishedOrQuitTheGame = true;
            }
            

            var sut = state.Board.Pieces;

            Assert.AreEqual(sut.Count,0);
            


        }




    }
}
