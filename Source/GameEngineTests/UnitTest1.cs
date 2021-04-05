using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using System.Collections.Generic;

namespace GameEngineTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Dice_Should_Be_SixSided()           // Warning! This test may, extremely rarely, give a false positive even if the dice function is broken.
        {
            bool NoRollOverSixOrBelowOne = true;
            for(int i = 0; i < 1000; i++)
            {
                int roll = Dice.Roll();
                if (!(roll >= 1 && roll <= 6))
                {
                    NoRollOverSixOrBelowOne = false;
                }
            }
            Assert.True(NoRollOverSixOrBelowOne);
        }
        [Test]
        public void NewGamestate_ShouldHaveAnEmpty_TurnList()
        {
            var sut = new Gamestate(new GameSettings(4, 40));
            Assert.AreEqual(sut.Turnlist.Count, 0);
        }
        [Test]
        public void AddTurnMethod_ShouldAddANewTurnToList()
        {
            var sut = new Gamestate(new GameSettings(4, 40));
            sut.AddTurn();
            Assert.AreEqual(sut.Turnlist.Count, 1);
        }


    }
}