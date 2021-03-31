using System;
using System.Threading;
using GameEngine;

namespace Renderer
{
    /* Classes in this namespace are used to render the game on screen based on the current game state.
     */


    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Step 1: Get user input for the game engine to use.
             * Step 2: Start up the game engine, sending in an object/array with arguments for the engine to use.
             * Step 3: Get data from the game engine to render onto the screen.
             * Step 4: When the game is over, dispose of the engine and ask the user if they want to play another game.
             */

            //While rolling the dice it should 'shuffel' some random numbers for a short while before it shows the real number.

            Engine newEngine = new Engine();
            Thread.Sleep(10000);
        }
    }
}
