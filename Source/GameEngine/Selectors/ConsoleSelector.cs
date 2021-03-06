using GameEngine.Models;
using GameEngine.EngineFunctionality;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Selectors
{
    [NotMapped]
    
    
    
    public class ConsoleSelector : ISelector
    {

        public Turn Selector(Gamestate s, Turn currentTurn, List<int> selectionList)
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
