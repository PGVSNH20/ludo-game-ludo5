﻿using GameEngine.Classes;
using GameEngine.EngineFunctionality;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Selectors
{
    public class ConsoleSelector : ISelector
    {

        public Turn Selector(Turn currentTurn, List<int> selectionList)
        {
            Console.WriteLine("The following are the pieces you may move:");
            foreach (int i in selectionList)
            {
                Console.WriteLine($"Piece {i}");
            }
            return Movement.CheckIfValidSelection(currentTurn, selectionList);
        }
    }
}
