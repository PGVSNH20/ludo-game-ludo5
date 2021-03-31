using NUnit.Framework;
using GameEngine;

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
    }
}