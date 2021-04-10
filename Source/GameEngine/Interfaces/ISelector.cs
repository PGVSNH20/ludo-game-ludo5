using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface ISelector
    {
        Turn Selector(Turn currentTurn, List<int> selectionList);
    }
}
