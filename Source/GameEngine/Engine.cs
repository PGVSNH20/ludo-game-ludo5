using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameEngine
{
	public class Engine
    {
		public Gamestate State { get; set; }

		public Engine(GameSettings settings)
        {
			State = new Gamestate(settings);
		}

        #region Game start and main loop
        public void StartGame()
		{
			Console.WriteLine($"Game Starting, welcome");
			foreach (Classes.Player player in State.Players)
            {
                Console.WriteLine($"     {player.Name}");
			}
			Console.WriteLine("We hope you'll enjoy our game!\nPress Enter to continue...");
			Console.ReadLine();
			GameLoop();
		}
		private void GameLoop()
        {
			bool gameHasNoWinner = true;
			while (gameHasNoWinner)
            {
				while (!EngineFunctionality.PlayerFunctions.CheckIfActivePlayerIsInTheGame(State)) { NextPlayer(); }

				Turn currentTurn = new();
				Console.WriteLine("Press enter to roll the dice");
				Console.ReadLine();
				currentTurn.Roll = Dice.Roll();
				Console.WriteLine($"{State.Players[State.ActivePlayer].Name} rolled a {currentTurn.Roll}");
				if (Movement.AreThereLegalMoves((int)currentTurn.Roll, State))
                {
                    List<int> legalPieces = Movement.ListLegalMoves((int)currentTurn.Roll, State);  // Kommer behöva nån typ av objekt
                    Movement.PrintLegalMoves(legalPieces);
                    currentTurn = Movement.CheckIfValidSelection(currentTurn, legalPieces); // rekursiv algoritm, antingen gör spelaren rätt eller så krashar spelet av en stack overflow?
                                                                                   // Här sätts Turn.PieceID
                    ExecuteTurn(currentTurn);
                    NextPlayer();
                    gameHasNoWinner = IsTheGameFinished();
                }
                else
                {
					Console.WriteLine("No legal moves found, moving to next player");
					NextPlayer();
                }
				State.Turnlist.Add(currentTurn);
                if (PlayerFunctions.CheckIfActivePlayerHasWon(State))
                {
                    State.PlayersStillPlaying.RemoveAt(State.ActivePlayer);
					if (State.PlayersStillPlaying.Count < 2) gameHasNoWinner = false;
                }
            }
        }
        #endregion

        #region Player checks
        #endregion

        private bool IsTheGameFinished()
        {
			int numberOfActivePlayers = 0;
			foreach (Classes.Player p in State.Players)
            {
				if (p.FinishedOrQuitTheGame == false) numberOfActivePlayers++;
            }
			return numberOfActivePlayers >= 2;
        }

        #region Movement checks and handling
        
        #endregion
        private void NextPlayer()
        {
			// Only call this method if you've already checked that the next active player should be found.
			State.ActivePlayer++;
			if (State.ActivePlayer == State.Players.Count) State.ActivePlayer = 0;
			// It increments the ActivePlayer variable.
			// If ActivePlayer is equal to Players.Count it means that it should roll over to zero (since Players is a list starting from 0, not one.)
        }
		private void ExecuteTurn(Turn currentTurn)
        {
			// PieceID and Roll are set to null when the Turn-object is first created.
			if (String.IsNullOrEmpty(Convert.ToString(currentTurn.PieceID))) return;
			if (String.IsNullOrEmpty(Convert.ToString(currentTurn.Roll))) return;
			/*
			 * Alright, let's do this again, and better this time.
			 * The two above just make sure the turn entered is valid, if not, it breaks.
			 * This is important for turns that may have been stored but not executed, for example due to rolling invalid values.
			 * Step one - check if the piece is in the nest. If it is, then the roll is a six, and it's simply meant to exit the nest and enter play.
			 * Step two - check if the piece is in the home stretch.
			 *		HOLD IT: The ListLegalMoves method has already filtered out any problematic values.
			 * Step three - check if it overflows. If it does, it'll need to enter the homestretch, which is the same area for all players.
			 * Step four - check if it enters the goal, if it does its position should be set to -2.
			 * Step five - check if the square it enters is safe, and if not, if any other pieces are on it.
			 *		Any other pieces on the same non-safe square should have their positions set to -1.
			 */
			int roll = (int)currentTurn.Roll;
			int pieceId = (int)currentTurn.PieceID;
			int piecePosition = State.Board.Pieces[pieceId].PiecePosition;
			int startPosition = State.Board.StartingPositions[State.ActivePlayer];
			int boardSize = State.Board.MainBoard.Count - 1; // If the board has 40 squares, then ID 40 is the first square of the home stretch...

			switch (piecePosition) // This switch decides how to move the piece forward.
            {
				case -1:
					piecePosition = startPosition;
					break;
				default :
					if (piecePosition > boardSize) // Is on HomeStretch. Has already checked that it can move.
                    {
						piecePosition += roll;
						break;
					}
					if (piecePosition + roll >= boardSize) // checks if it should roll over or go to player 1's home stretch
                    {
						if (startPosition != 0) // If not player one, loop around
						{
							piecePosition = piecePosition + roll - boardSize;
							break;
						}
						piecePosition += roll; // If player one, enter home stretch or goal
						break;
					}
					if (piecePosition < startPosition && piecePosition + roll >= startPosition)
                    {
						piecePosition = boardSize + piecePosition + roll - startPosition;
						break; // Basically, piecePosition + roll - startPosition is the amount of overflow when you reach the end of your track... And boardSize is, well, end of the board.
                    } // I am too tired to do the math on whether I should be removing a 1 from boardSize atm. Testing will show this later. I guess? Could do math, but...
					piecePosition += roll;
					break;
			}
			if (piecePosition == State.Board.MainBoard.Count + 6) // Checks if the piece is "in the goal", if it is it's set to the true goal value, player gets a point, and checks if player has finished the game.
			{
				piecePosition = -2;
				State.Players[State.ActivePlayer].Score++;
				if (State.Players[State.ActivePlayer].Score == 4) PlayerHasFinishedGame(State.ActivePlayer);
			}
			State.Board.Pieces[pieceId].PiecePosition = piecePosition;

			// TODO: Add logic to check if player pushes away other players' pieces

			Console.WriteLine($"Piece moved to {piecePosition}");
        }

        private void PlayerHasFinishedGame(int activePlayer)
        {
			for (int i = 0; i < State.PlayersStillPlaying.Count; i++)
            {
				if (State.PlayersStillPlaying[i].Id == activePlayer)
                {
					State.PlayersStillPlaying.RemoveAt(activePlayer);
					return;
                }
            }
        }
    }
}
