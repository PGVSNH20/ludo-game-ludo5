using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using System.Collections.Generic;

namespace GameEngineTests
{
    class EngineMovementTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void ListLegalMoves_ShouldReturnFourObjects_WhenGivenARollOfSixAtStartOfGame()
        {
            Gamestate state = new(new GameSettings(4, 40));
            var sut = Movement.ListLegalMoves(6, state);
            Assert.AreEqual(4, sut.Count);
        }

    }
}
