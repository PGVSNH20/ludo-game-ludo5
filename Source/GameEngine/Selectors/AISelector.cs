using GameEngine.Classes;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Selectors
{
    public class AISelector : ISelector
    {
        public Turn Selector(Turn currentTurn, List<int> selectionList)
        {
            currentTurn.PieceID = selectionList[0];
            return currentTurn;
        }
    }
}
