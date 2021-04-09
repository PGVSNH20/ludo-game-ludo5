using System;
using System.Collections.Generic;
using System.Threading;
using GameEngine;
using GameEngine.Classes;
using GameEngine.Selectors;
using GameEngine.Dice;


namespace Renderer
{
    /* Classes in this namespace are used to render the game on screen based on the current game state.
     */


    class Program
    {
        static void Main(string[] args)
        {
            /*
             * TODO: IMPORTANT! Commented out ReadLine-calls in Movement and Engine for testing purposes - reimplement them later!
             */
            var renderer = new ConsoleRenderer();
            renderer.Setup().Start();
            var renderer2 = new ConsoleRenderer();
            renderer2.Setup().Start();
        }
    }
}
