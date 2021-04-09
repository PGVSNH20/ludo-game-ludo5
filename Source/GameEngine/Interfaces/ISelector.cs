using GameEngine.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface ISelector
    {
        Turn Selector(Gamestate state, Turn currentTurn, List<int> selectionList);
    }
}
