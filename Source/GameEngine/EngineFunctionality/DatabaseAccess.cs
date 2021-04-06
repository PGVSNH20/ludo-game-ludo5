using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.EngineFunctionality
{
    class DatabaseAccess
	{
		public void Save()
		{
			// Takes the current gamestate and saves it to the database
			throw new NotImplementedException();
		}
		public Engine Load()
		{
			// Takes a gamestate from the database and sets it up to allow play to continue
			// This should not call the GameLoop untill the gamestate is fully set up - instead it should do a foreach on the turnlist and send all turns to the ExecuteTurn-method.
			throw new NotImplementedException();
		}
	}
}
