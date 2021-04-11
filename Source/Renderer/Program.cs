using System;
using System.Collections.Generic;
using System.Threading;
using GameEngine;
using GameEngine.Models;
using GameEngine.Selectors;
using GameEngine.Dice;
using System.Diagnostics;
namespace Renderer
{

    class Program
    {
        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer();
            renderer.Setup().Start();
            //Thread.Sleep(100);
            //var renderer2 = new ConsoleRenderer();
            //renderer2.Setup().Start();
            //OneHundred.CountThis();
        }
    }
}
