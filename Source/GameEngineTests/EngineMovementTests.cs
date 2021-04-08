using NUnit.Framework;
using GameEngine;
using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using System.Collections.Generic;

namespace GameEngineTests
{
    class EngineMovementTests
    {
        // Note: With a Board size of 40, squares with Id 0 through 39 are MainBoard, while squares 40 through 44 are HomeStretch
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void ListLegalMoves_ShouldReturnFourObjects_WhenGivenARollOfSixAtStartOfGame()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));

            var sut = Movement.ListLegalMoves(6, state);
            Assert.AreEqual(4, sut.Count);
        }

        [Test]
        public void ListLegalMoves_ShouldReturnOneObject_WhenGivenARollOfFiveWithOnePieceInPlay()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            state.Board.Pieces[0].PiecePosition = 0;

            var sut = Movement.ListLegalMoves(5, state);
            Assert.AreEqual(1, sut.Count);
        }
        [Test]
        public void ListLegalMoves_ShouldReturnZeroObjects_WhenGivenARollOfOneAtStartOfGame()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));

            var sut = Movement.ListLegalMoves(1, state);
            Assert.AreEqual(0, sut.Count);
        }
        [Test]
        public void ListLegalMoves_ShouldReturnOneObject_WhenGivenARollOfOneWithASinglePieceAtTheEndOfTheHomeStretch()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            state.Board.Pieces[0].PiecePosition = 44;

            var sut = Movement.ListLegalMoves(1, state);
            Assert.AreEqual(1, sut.Count);
        }
        [Test]
        public void ListLegalMoves_ShouldReturnZeroObjects_WhenGivenARollOfTwoWithASinglePieceAtTheEndOfTheHomeStretch()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            state.Board.Pieces[0].PiecePosition = 44;

            var sut = Movement.ListLegalMoves(2, state);
            Assert.AreEqual(0, sut.Count);
        }
        [Test]
        public void ListLegalMoves_ShouldReturnZeroObjects_WhenGivenARollOfSixWithAllPiecesOnTheHomeStretch()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            state.Board.Pieces[0].PiecePosition = 40;
            state.Board.Pieces[1].PiecePosition = 41;
            state.Board.Pieces[2].PiecePosition = 42;
            state.Board.Pieces[3].PiecePosition = 44;

            var sut = Movement.ListLegalMoves(6, state);
            Assert.AreEqual(0, sut.Count);
        }
        [Test]
        public void ListLegalMoves_ShouldReturnOneObject_WhenGivenARollOfTwoWithOnePieceRightNextToTheGoalAndAnotherFurtherBackOnTheHomeStretch()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            state.Board.Pieces[0].PiecePosition = 40;
            state.Board.Pieces[3].PiecePosition = 44;

            var sut = Movement.ListLegalMoves(2, state);
            Assert.AreEqual(1, sut.Count);
        }

        [Test]
        public void CheckIfPieceCanMove_ShouldReturnTrue_GivenARollOfSixAndPieceInNest()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            var piece = new Piece(100, 100);
            piece.PiecePosition = -1;

            var sut = Movement.CheckIfPieceCanMove(6, piece, state);
            Assert.True(sut);
        }
        [Test]
        public void CheckIfPieceCanMove_ShouldReturnFalse_GivenARollOfFiveAndPieceInNest()
        {
            var players = new List<string>();
            players.Add("M");
            players.Add("R");
            players.Add("S");
            players.Add("Y");
            var state = new Gamestate(new GameSettings(players, 40));
            var piece = new Piece(100, 100);
            piece.PiecePosition = -1;

            var sut = Movement.CheckIfPieceCanMove(5, piece, state);
            Assert.False(sut);
        }
        // CheckIfPieceCanMove is integral to the function of ListLegalMoves which has already been shown to work as expected. As such, making more tests on this method seems redundant.
        // AreThereLegalMoves also relies on CheckIfPieceCanMove, and any test of that method is essentially also a test of CheckIfPieceCanMove moreso than anything new.
        // Given this, I should probably have made most tests aimed at CheckIfPieceCanMove() instead, but what's done is done.
        // CheckIfValidSelection tests the user's input and is therefore difficult if not impossible to test
    }
}
