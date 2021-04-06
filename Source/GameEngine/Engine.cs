using GameEngine.Classes;
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
		Gamestate state;

		public Engine(GameSettings settings)
        {
			state = new Gamestate(settings);
		}
		#region Save- and Load methods
		public void Save()
		{
			// Takes the current gamestate and saves it to the database
			throw new NotImplementedException();
		}
		public Engine Load()
		{
			// Takes a gamestate from the database and sets it up to allow play to continue
			// This should not call the GameLoop untill the gamestate is fully set up - instead it should do a foreach on the turnlist and send all turns to the ExecuteTurn-method.
			throw new NotImplementedException();
		}
        #endregion

        #region Game start and main loop
        public void StartGame()
		{
			Console.WriteLine($"Game Starting, welcome");
			foreach (Player player in state.Players)
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
				while (!CheckIfActivePlayerIsInTheGame()) { NextPlayer(); }

				Turn currentTurn = new();
				Console.WriteLine("Press enter to roll the dice");
				Console.ReadLine();
				currentTurn.Roll = Dice.Roll();
				Console.WriteLine($"{state.Players[state.ActivePlayer].Name} rolled a {currentTurn.Roll}");
				if (AreThereLegalMoves((int)currentTurn.Roll))
                {
                    List<int> legalPieces = ListLegalMoves((int)currentTurn.Roll);  // Kommer behöva nån typ av objekt
                    PrintLegalMoves(legalPieces);
                    currentTurn = CheckIfValidSelection(currentTurn, legalPieces); // rekursiv algoritm, antingen gör spelaren rätt eller så krashar spelet av en stack overflow?
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
				state.Turnlist.Add(currentTurn);
                if (CheckIfActivePlayerHasWon())
                {
					state.PlayersStillPlaying.RemoveAt(state.ActivePlayer);
					if (state.PlayersStillPlaying.Count < 2) gameHasNoWinner = false;
                }
            }
        }
        #endregion

        #region Player checks
        private bool CheckIfActivePlayerIsInTheGame()
        {
            foreach (Player p in state.PlayersStillPlaying)
            {
				if (state.ActivePlayer == p.Id) return true;
			}
			return false;
        }

        private bool CheckIfActivePlayerHasWon()
        {
			List<Piece> pieces = GetActivePlayersPieces();
			foreach (Piece p in pieces)
            {
				if (p.PiecePosition != -2) return false;
            }
			return true;
        }
        #endregion
        private static void PrintLegalMoves(List<int> legalPieces)
        {
            Console.WriteLine("Please select which piece to move.");
            foreach (int i in legalPieces)
            {
                Console.WriteLine($"Piece {i}");
            }
        }

        private bool IsTheGameFinished()
        {
			int numberOfActivePlayers = 0;
			foreach (Player p in state.Players)
            {
				if (p.FinishedOrQuitTheGame == false) numberOfActivePlayers++;
            }
			return numberOfActivePlayers >= 2;
        }

        #region Movement checks and handling
        private Turn CheckIfValidSelection(Turn currentTurn, List<int> legalPieces)
        {
            try
			{
				int input = Convert.ToInt32(Console.ReadLine());
				if (legalPieces.Contains(input))
                {
					currentTurn.PieceID = input;
					return currentTurn;
                }
				Console.WriteLine("Invalid entry");
				PrintLegalMoves(legalPieces);
				return CheckIfValidSelection(currentTurn, legalPieces);

			}
            catch
            {
				Console.WriteLine("Invalid entry");
				return CheckIfValidSelection(currentTurn, legalPieces);
            }
        }

        private List<int> ListLegalMoves(int roll)
        {
			List<Piece> pieces = GetActivePlayersPieces();
			List<int> listOfMoveablesIds = new();
			foreach (Piece p in pieces)
            {
				if (CheckIfPieceCanMove(roll, p)) listOfMoveablesIds.Add(p.HiddenID);
            }
			return listOfMoveablesIds;
        }

        private bool AreThereLegalMoves(int roll)
        {
			List<Piece> activePlayerPieces = GetActivePlayersPieces();
			foreach (Piece p in activePlayerPieces)
            {
				if (CheckIfPieceCanMove(roll, p)) return true;
            }
			return false;
        }

        private bool CheckIfPieceCanMove(int roll, Piece p)
		{
			if (p.PiecePosition == -1) return roll == 6;
			if (p.PiecePosition == -2) return false;
			if (p.PiecePosition + roll <= state.Board.MainBoard.Count + 5) return true;
			return false;
		}

        private List<Piece> GetActivePlayersPieces()
        {
			List<Piece> activePlayerPieces = new List<Piece>();
			foreach (Piece p in state.Board.Pieces)
            {
				if (p.PlayerID == state.ActivePlayer) activePlayerPieces.Add(p);
            }
			return activePlayerPieces;
        }
        #endregion
        private void NextPlayer()
        {
			// Only call this method if you've already checked that the next active player should be found.
			state.ActivePlayer++;
			if (state.ActivePlayer == state.Players.Count) state.ActivePlayer = 0;
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
			int piecePosition = state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition;
			int startPosition = state.Board.StartingPositions[state.ActivePlayer];

			if (piecePosition == -1)
			{ 
				state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = startPosition;
			}
			else if (piecePosition > state.Board.HomeStretch.Count - 1)
            {
				if (piecePosition + currentTurn.Roll == state.Board.HomeStretch.Count + 5) state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = -2;
				else if (piecePosition + currentTurn.Roll < state.Board.HomeStretch.Count + 5) state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition += (int)currentTurn.Roll;
			}
			else if (piecePosition < state.Board.StartingPositions[state.ActivePlayer] 
				&& piecePosition + currentTurn.Roll >= startPosition)
            {
				int rollOverflow = piecePosition + (int)currentTurn.Roll - startPosition;
				if (rollOverflow == 6) state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = -2;
				else state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition = state.Board.HomeStretch[rollOverflow].Id;
			}
            else
            {
				state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition += (int)currentTurn.Roll;
			}
			Console.WriteLine($"Piece moved to {state.Board.Pieces[(int)currentTurn.PieceID].PiecePosition}");
			// TODO: Skriv klart? Är det klart?
        }
    }
}
