using NUnit.Framework;
using GameEngine.Dice;
using GameEngine.Models;
using System.Collections.Generic;
using GameEngine.Interfaces;
using GameEngine.Selectors;

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
            var NoRollOverSixOrBelowOne = true;
            IDice sut = new AIDice();
            for(int i = 0; i < 1000; i++)
            {
                int roll = sut.Roll();
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
            playerNames.Add(new("M", new AIDice(), new AISelector()));
            playerNames.Add(new("R", new AIDice(), new AISelector()));
            var sut = new Gamestate(new GameSettings(playerNames, 40));
            Assert.AreEqual(0, sut.Turnlist.Count);
        }
        [Test]
        public void AddTurnMethod_ShouldAddANewTurnToList()
        {


            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new AIDice(), new AISelector()));
            playerNames.Add(new("R", new AIDice(), new AISelector()));
            var sut = new Gamestate(new GameSettings(playerNames, 40));
            sut.AddTurn();
            Assert.AreEqual(1, sut.Turnlist.Count);
        }


    }
}