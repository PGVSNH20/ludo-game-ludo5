using GameEngine.Classes;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		GameSettings Settings;

		public Engine(GameSettings settings)
        {
			Settings = settings;
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

		private void StartGame()
        {
			throw new NotImplementedException();
		}

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
			 */
			throw new NotImplementedException();
        }

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
