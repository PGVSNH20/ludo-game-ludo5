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
	/* Classes in this namespace are meant to modify the game's state based on inputs, doing things such as rolling dice and moving figures around the board.
     * 
    Piece
		Id		int
	Player
		Id		int
		AI		bool
		Pieces	List<Piece>
		Score	int
	Square
		Id		int
		Pieces	List<Piece>
		Safe	int
	Board
		Squares List<Square>
		Blue	List<Square>
		Yellow	List<Square>
		Red		List<Square>
		Green	List<Square>
		Start	Square

	A Piece is a single unit for its owner to control.
	A Player is either a living being playing the game or an AI.
	A Square is a square on the board.
	A Board is the play area.

	A Player controls all pieces in their Pieces list.
	A Square can hold several Pieces at once from the same player,
		or from multiple players if one of them has the same Id as is stored in the "Safe" value.
		The Safe int determines which player's safe zone it is. 1 for blue, 2 for yellow, 3 for red, 4 for green.
			If it's not a safe zone it's 0.
	A Board has a number of Square objects in the Squares list that represent all the squares going around the board.
		All inactive Pieces are on the Square Board.Start
	A Board also has a list of Squares for each color representing the final stretch for that particular player.
		The player's Id determines their color - 1 for blue, 2 for yellow, 3 for red and 4 for green.
	If the Board's Squares list has 40 Square objects (standard according to old rules)
		then Player 1 would travel from 0 to 39 before entering their Home Stretch, which the Board calls Blue
		then Player 2 would travel from 10 to 29 before entering their Home Stretch, which the Board calls Yellow
		then Player 3 would travel from 20 to 19 before entering their Home Stretch, which the Board calls Red
		then Player 4 would travel from 30 to 9 before entering their Home Stretch, which the Board calls Green
			If the number of squares changes, it has to change by a factor of four
				44, 48, 52 are all acceptable numbers.
				43, 49, 51 are not acceptable numbers.
	When a player that is not player 1 rolls a value that would make them move past square 39
		the game should check how many spaces past 39 they would go and loop them around to the start.
     * 
     */
	public class Engine
    {
		Gamestate state;

		public Engine(GameSettings settings)
        {
			state = new Gamestate(settings);
		}

		public void Save()
		{
			// Takes the current gamestate and saves it to the database
			throw new NotImplementedException();
		}
		public Engine Load()
		{
			// Takes a gamestate from the database and sets it up to allow play to continue
			throw new NotImplementedException();
		}

		public void StartGame()
		{
			Console.WriteLine($"Game Starting, welcome\n");
			foreach (Player player in state.Players)
            {
				Console.WriteLine($"     {player.Name}\n");
			}
			Console.WriteLine("We hope you'll enjoy our game!");
			Thread.Sleep(5000);
			GameLoop();
			/*
			 * How the game should go:
			 * StartGame() should set up the board based on the GameSettings
			 * it then calls the GameLoop, where we'll be stuck for the remainder of the game.
			 */
		}
		private void GameLoop()
        {
			bool gameHasNoWinner = true;
			while (gameHasNoWinner)
            {
				Turn currentTurn = new Turn();
				Console.WriteLine("Press enter to roll the dice");
				Console.ReadLine();
				currentTurn.Roll = Dice.Roll();
				Console.WriteLine($"{state.Players[state.ActivePlayer].Name} rolled a {currentTurn.Roll}");
				if (AreThereLegalMoves(currentTurn.Roll))
                {
					List<int> legalPieces = ListLegalMoves(currentTurn.Roll);  // KOmmer behöva nån typ av objekt
					Console.WriteLine("Please select which piece to move.");
					foreach(int i in legalPieces)
                    {
						Console.WriteLine(i);
                    }
					currentTurn = CheckIfValidSelection(currentTurn); // rekursiv algoritm, antingen gör spelaren rätt eller så krashar spelet?
																	  // Här sätts Turn.PieceID
					ExecuteTurn(currentTurn);
					state.ActivePlayer = NextPlayer();
					gameHasNoWinner = IsTheGameFinished();
                }
                else
                {
					Console.WriteLine("No legal moves found, moving to next player");
                }
            }
			/*
			 * Here in the GameLoop() we use a while(gameHasNoWinner){ DoStuff() }
			 * First step is to create a new Turn() object.
			 * Then the Turn.Roll value is set to a value from the Dice.Roll() method.
			 * Then we call a "see if there's a valid move" method which checks the current state of the game and sees if the ActivePlayer can make a valid move.
			 * If no, then we set Turn.PieceID to -1 (to indicate no piece is moved) and call the NextPlayer() method which checks who is the next valid ActivePlayer.
			 * If there is a valid move, call a method which indicates to the player exactly what pieces are valid this turn, and let the player pick one.
			 * Store their choice in Turn.PieceID.
			 * Then send the entire Turn-object into the ExecuteTurn() method to have the turn play out. ExecuteTurn() should return a bool which decides if the ActivePlayer
			 * remains the ActivePlayer or if you should call the NextPlayer() method to switch to the next one.
			 * Then the loop reaches its end, and, if two or more players still remain in the game, the next turn starts.
			 */
        }

        private bool IsTheGameFinished()
        {
            throw new NotImplementedException();
        }

        private Turn CheckIfValidSelection(Turn currentTurn)
        {
            throw new NotImplementedException();
        }

        private List<int> ListLegalMoves(int roll)
        {
            throw new NotImplementedException();
        }

        private bool AreThereLegalMoves(int roll)
        {
            throw new NotImplementedException();
        }

        private int NextPlayer()
        {
			throw new NotImplementedException();
        }
		private void ExecuteTurn(Turn currentTurn)
        {
			throw new NotImplementedException();
        }

		/*
		private void TakeTurn()
        {
			/* A single turn should look something like this:
			 * The ActivePlayer is allowed to roll the dice.
			 * The system checks to see if there is at least one legal move, and if there is, it finds all pieces the ActivePlayer controls that can use the roll.
			 * The ActivePlayer gets to, if possible, choose which Piece is going to use the roll to move.
			 * Then an evaluation is made to see if the ActivePlayer gets to go again (knocked out an opponent's piece, rolled a 6 etc)
			 * If ActivePlayer gets to make another turn, call TakeTurn()
			 * Else increment the ActivePlayer value (if the value is larger than the number of players, overflow back to lowest numbered player) and then call TakeTurn()
			 * This means we only need one Move() method which checks the gamestate to see which player is currently active, and then moves the correct player's piece.
			 * We will, however, need to make sure that
			 *		The ActivePlayer can only select their own pieces
			 *		The ActivePlayer can only select pieces that have legal moves to make
			 *		If no legal moves are available, the turn is passed to the next player
			 *//*
			throw new NotImplementedException();
        }*/

        /*
			Step 1: Get information about how to set up
				How many players?
				How many of those are AI-controlled?
				What size board are you playing on (if variable size is capable)
				Load from a previously saved state?
			Step 2: Set up the board
				Generate the squares
				Generate the players
				Place the players' Pieces on the Start square
			Step 3: Start up the game loop
				Play the game!
				Save game if need be?
			Step 4: Game completed.
				Save replay? And other Database stuff.
		*/
    }
}
