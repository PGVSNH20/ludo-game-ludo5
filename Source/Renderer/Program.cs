using System;
using System.Collections.Generic;
using System.Threading;
using GameEngine;
using GameEngine.Classes;


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

            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new Dice()));
            playerNames.Add(new("R", new Dice()));
            playerNames.Add(new("S", new Dice()));
            playerNames.Add(new("Y", new Dice()));
            Engine newEngine = new Engine(new GameSettings(playerNames, 32));
            newEngine.StartGame();
        }
    }
}
