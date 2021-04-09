using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using System.Collections.Generic;
using GameEngine.Interfaces;

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
            IDice dice = new AIDice();
            for(int i = 0; i < 1000; i++)
            {
                int roll = dice.Roll();
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

            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new Dice()));
            playerNames.Add(new("R", new Dice()));
            var sut = new Gamestate(new GameSettings(playerNames, 40));
            Assert.AreEqual(sut.Turnlist.Count, 0);
        }
        [Test]
        public void AddTurnMethod_ShouldAddANewTurnToList()
        {


            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new Dice()));
            playerNames.Add(new("R", new Dice()));
            var sut = new Gamestate(new GameSettings(playerNames, 40));
            sut.AddTurn();
            Assert.AreEqual(sut.Turnlist.Count, 1);
        }


    }
}