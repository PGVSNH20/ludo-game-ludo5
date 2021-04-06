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
            Engine newEngine = new(new GameSettings(40, 4));
            var sut = Movement.ListLegalMoves(6, newEngine.State);
            Assert.AreEqual(4, sut.Count);
        }

    }
}
