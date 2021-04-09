using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using System.Collections.Generic;
using GameEngine.Selectors;

namespace GameEngineTests
{
    class PlayerFunctionsTests
    {

        [Test]
        
        public void NoActivePlayersNoActivePieces()
        {
            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new AIDice(), new AISelector()));
            playerNames.Add(new("R", new AIDice(), new AISelector()));
            playerNames.Add(new("S", new AIDice(), new AISelector()));
            playerNames.Add(new("Y", new AIDice(), new AISelector()));
            var state = new Gamestate(new GameSettings(playerNames, 40));

            for (int x = 0; x < state.Players.Count; x++)
            {
                state.Players[x].FinishedOrQuitTheGame = true;
            }
            

            var sut = state.Board.Pieces;

            Assert.AreEqual(sut.Count, 0);
            


        }




    }
}
