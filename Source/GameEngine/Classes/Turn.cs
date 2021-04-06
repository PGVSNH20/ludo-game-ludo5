using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    /*
     * This class is used to represent a single turn (or, if multiple rolls are made in one turn, a part of a turn)
     * The important parts to consider is the ID of the gamepiece selected (-1 represents no piece selected, probably because no valid move is allowed)
     * and the roll on the dice.
     * By storing a list of Turn objects in the game state, a table can be created at the end of the game which can act as a replay for the game,
     * allowing the engine to recreate a played game accurately.
     * It should not be necessary to save more information, like the active player, because if you remove the rolling of the dice from the game, it becomes fully predictable.
     * The rolling of the dice is the only random element, the rest is deterministic.
     * By having this class, the engine can also start by making a new Turn object, feeding the roll from the Dice class into the new Turn's Roll value
     * Then the class saves the player's choice of PieceID (if relevant)
     * And finally the Turn can be fed into a method for actually executing the Turn and setting up the next.
     */
    public class Turn
    {
        public int? PieceID { get; set; } = null;
        public int? Roll { get; set; } = null;
        public Turn()
        {

        }
    }
}
