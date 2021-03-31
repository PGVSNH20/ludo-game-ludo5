using System;
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
	class Engine
    {
    }
}
