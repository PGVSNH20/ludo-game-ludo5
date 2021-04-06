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
			 * Step three - check if it overflows. If it does, it'll need to enter the homestretch, which is the same area for all players.
			 * Step four - check if it enters the goal, if it does its position should be set to -2.
			 * Step five - check if the square it enters is safe, and if not, if any other pieces are on it.
			 *		Any other pieces on the same non-safe square should have their positions set to -1.
			 */
			int piecePosition = State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition;
			int startPosition = State.Board.StartingPositions[State.ActivePlayer];

			if (piecePosition == -1)
			{ 
				State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = startPosition;
			}
			else if (piecePosition > State.Board.HomeStretch.Count - 1)
            {
				if (piecePosition + currentTurn.Roll == State.Board.HomeStretch.Count + 5) State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = -2;
				else if (piecePosition + currentTurn.Roll < State.Board.HomeStretch.Count + 5) State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition += (int)currentTurn.Roll;
			}
			else if (piecePosition < State.Board.StartingPositions[State.ActivePlayer] 
				&& piecePosition + currentTurn.Roll >= startPosition)
            {
				int rollOverflow = piecePosition + (int)currentTurn.Roll - startPosition;
				if (rollOverflow == 6) State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = -2;
				else State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = State.Board.HomeStretch[rollOverflow].Id;
			}
            else
            {
				State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition += (int)currentTurn.Roll;
			}
			Console.WriteLine($"Piece moved to {State.Board.Pieces[(int)currentTurn.PieceID].PiecePosition}");
			// TODO: Skriv klart? Är det klart?
        }
    }
}
