using GameEngine.Data;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.EngineFunctionality
{
    class DatabaseAccess
	{
		public static void Save(Gamestate state)
		{
			// Takes the current gamestate and saves it to the database
			using LudoContext context = new();
			SaveData data = new();
			data.Settings = state.Settings;
			data.ExecutedTurns = state.Turnlist;
			context.Save.Add(data);
			context.SaveChanges();
		}
		public static void Load(int i)
		{
			// Takes a gamestate from the database and sets it up to allow play to continue
			// This should not call the GameLoop untill the gamestate is fully set up - instead it should do a foreach on the turnlist and send all turns to the ExecuteTurn-method.
			using LudoContext context = new();
			SaveData data = context.Save
				.Where(p => p.Id == i)
				.FirstOrDefault();
			Engine engine = new(data.Settings);
			engine.RunLoadedTurns(data.ExecutedTurns);
		}
	}
}
