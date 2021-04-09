using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace GameEngine
{
	public class Engine
    {
		public Gamestate State { get; set; }

		public Engine(GameSettings settings)
        {
			State = new Gamestate(settings);
		}

        public void StartGame()
		{
			Console.WriteLine($"Game Starting, welcome");
			foreach (Player player in State.Players)
            {
                Console.WriteLine($"     {player.Name}");
			}
			Console.WriteLine("We hope you'll enjoy our game!\nPress Enter to continue...");
			// Console.ReadLine();
			GameLoop();
		}
		private void GameLoop()
        {
			bool gameHasNoWinner = true;
            List<Player> playerWinOrder = new();
            // IDice Dice = new Dice();            // TODO: IDice should actually be stored on a player-basis so that you can get the ActivePlayer's Dice (automatic for AI for example)
			while (gameHasNoWinner)
            {
				while (!PlayerFunctions.CheckIfActivePlayerIsInTheGame(State)) { NextPlayer(); }

				Turn currentTurn = new();
				// Console.ReadLine();
				currentTurn.Roll = State.Players[State.ActivePlayer].Dice.Roll();
				Console.WriteLine($"{State.Players[State.ActivePlayer].Name} rolled a {currentTurn.Roll}");
				if (Movement.AreThereLegalMoves((int)currentTurn.Roll, State))
                {
                    //List<int> legalPieces = Movement.ListLegalMoves((int)currentTurn.Roll, State);  // Kommer behöva nån typ av objekt
                    //Movement.PrintLegalMoves(legalPieces);
                    //currentTurn = Movement.CheckIfValidSelection(currentTurn, legalPieces); // rekursiv algoritm, antingen gör spelaren rätt eller så krashar spelet av en stack overflow?
                    // Här sätts Turn.PieceID
                    currentTurn = State.Players[State.ActivePlayer].Selector
                                                                        .Selector(
                                                                            currentTurn, Movement.ListLegalMoves(
                                                                                (int)currentTurn.Roll, State
                                                                                ));
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
                // PrintPiecePositions();
                // PrintPlayersStillPlaying();
                if (State.Players[State.ActivePlayer].Score == 4)
                {
                    playerWinOrder = RemoveActivePlayerFromTheGame(playerWinOrder);
					// if (State.PlayersStillPlaying.Count < 2) 
                        gameHasNoWinner = false;
                }
            }
            Console.WriteLine($"Player {playerWinOrder[0].Name} won the game!\n~~Congratulations~~");
        }

        private void PrintPlayersStillPlaying()
        {
            foreach(Player p in State.Players)
            {
                if (p.Score != 4) Console.WriteLine(p.Id);
            }
        }

        private void PrintPiecePositions()
        {
            foreach (Piece p in State.Board.Pieces)
            {
                Console.WriteLine(p.PiecePosition);
            }
        }

        private List<Player> RemoveActivePlayerFromTheGame(List<Player> playerWinOrder)
        {
            for (int i = 0; i < State.PlayersStillPlaying.Count; i++)
            {
                if (State.PlayersStillPlaying[i].Id == State.ActivePlayer)
                {
                    playerWinOrder.Add(State.PlayersStillPlaying[i]);
                    State.PlayersStillPlaying.RemoveAt(i);
                    i = State.PlayersStillPlaying.Count;
                }
            }
            return playerWinOrder;
        }

        private bool IsTheGameFinished()
        {
			int numberOfActivePlayers = 0;
			foreach (Player p in State.Players)
            {
				if (p.FinishedOrQuitTheGame == false) numberOfActivePlayers++;
            }
			return numberOfActivePlayers >= 2;
        }

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
            int boardSize = State.Board.MainBoard.Count; // If the board has 40 squares, then ID 40 is the first square of the home stretch...

            piecePosition = PiecePositionCalculator(roll, piecePosition, startPosition, boardSize);
            if (piecePosition == State.Board.MainBoard.Count + 5) // Checks if the piece is "in the goal", if it is it's set to the true goal value, player gets a point, and checks if player has finished the game.
            {
                piecePosition = -2;
                State.Players[State.ActivePlayer].Score++;
                // if (State.Players[State.ActivePlayer].Score == 4) PlayerHasFinishedGame(State.ActivePlayer);
            }
            State.Board.Pieces[pieceId].PiecePosition = piecePosition;
            if (piecePosition >= 0 && piecePosition < boardSize) PiecePusher(piecePosition);

            // TODO: Add logic to check if player pushes away other players' pieces
            // Check that piecePosition is not -1, -2 or Mainboard.Count or higher

            Console.WriteLine($"Piece moved to {piecePosition}");
        }

        private void PiecePusher(int piecePosition)
        {
            // This should only be called if the Piece is still on the main board.
            if (State.Board.MainBoard[piecePosition].Safe) return;                          //escape the method if the square is a safe square.
            List<Piece> piecesOnTheSameSquare = FindPiecesOnSameSquare(piecePosition);      // Finds all pieces that are on the same square
            piecesOnTheSameSquare = SelectActivePlayerPieces(piecesOnTheSameSquare);     // Filters out the active player's own pieces
            foreach (Piece p in piecesOnTheSameSquare)                                      // And then moves the remainder, if any, to the nest at -1.
            {
                p.PiecePosition = -1;
            }
        }

        private List<Piece> SelectActivePlayerPieces(List<Piece> piecesOnTheSameSquare)
        {
            List<Piece> pieceList = new();
            foreach(Piece p in piecesOnTheSameSquare)
            {
                if (p.PlayerID != State.ActivePlayer) pieceList.Add(p);
            }
            return pieceList;
        }

        private List<Piece> FindPiecesOnSameSquare(int piecePosition)
        {
            List<Piece> pieceList = new();
            foreach (Piece p in State.Board.Pieces)
            {
                if (p.PiecePosition == piecePosition) pieceList.Add(p);
            }
            return pieceList;
        }

        private static int PiecePositionCalculator(int roll, int piecePosition, int startPosition, int boardSize)
        {
            switch (piecePosition) // This switch decides how to move the piece forward.
            {
                case -1:
                    piecePosition = startPosition;
                    break;
                default:
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

            return piecePosition;
        }

        private void PlayerHasFinishedGame(int activePlayer)
        {
			for (int i = 0; i < State.PlayersStillPlaying.Count; i++)
            {
				if (State.PlayersStillPlaying[i].Id == activePlayer)
                {
					State.PlayersStillPlaying.RemoveAt(i);
					return;
                }
            }
        }
    }
}
