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

            var playerNames = new List<PlayerSetting>();
            playerNames.Add(new("M", new ConsoleDice(), new ConsoleSelector()));
            playerNames.Add(new("R", new AIDice(), new AISelector()));
            playerNames.Add(new("S", new AIDice(), new AISelector()));
            playerNames.Add(new("Y", new AIDice(), new AISelector()));
            Engine newEngine = new Engine(new GameSettings(playerNames, 32));
            newEngine.StartGame();
        }
    }
}
