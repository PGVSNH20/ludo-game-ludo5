using GameEngine.Models;
using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Selectors
{
    [NotMapped]
    public class AISelector : ISelector
    {
        public Turn Selector(Turn currentTurn, List<int> selectionList)
        {
            currentTurn.PieceID = selectionList[0];
            return currentTurn;
        }
    }
}
