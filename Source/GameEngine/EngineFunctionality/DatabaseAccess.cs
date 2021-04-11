using GameEngine.Data;
using GameEngine.Dice;
using GameEngine.Interfaces;
using GameEngine.Models;
using GameEngine.Selectors;
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
			SaveData data = new(
				state.Settings.BoardSize,
				GetListOfPlayers(state),
				state.Turnlist
				);
			context.Save.Add(data);
			context.SaveChanges();
		}

        private static List<DbPlayer> GetListOfPlayers(Gamestate state)
        {
			List<DbPlayer> playerList = new();
			foreach (Player p in state.Players)
            {
				playerList.Add(new(
					p.Id,
					p.Name,
					GetTypeOfPlayer(p.Dice)
					));
            }
			return playerList;
        }

        private static int GetTypeOfPlayer(IDice dice)
        {
			string type = dice.GetType().ToString();
			switch (type)
            {
				case "GameEngine.Dice.AIDice": return 0;
				case "GameEngine.Dice.ConsoleDice": return 1;
				default: throw new NotImplementedException("Dice type not implemented in save function.");
			}
        }

        public static Engine Load(int i)
		{
			// Takes a gamestate from the database and sets it up to allow play to continue
			// This should not call the GameLoop untill the gamestate is fully set up - instead it should do a foreach on the turnlist and send all turns to the ExecuteTurn-method.
			using LudoContext context = new();
			SaveData data = context.Save
				.Where(p => p.Id == i)
				.FirstOrDefault();
			GameSettings settings = new();
			settings.BoardSize = data.Boardsize;
			settings.Players = ExtractPlayerlistFromLoadedData(data);
			Engine engine = new(settings);
			engine.RunLoadedTurns(data.ExecutedTurns);
			return engine;
		}

        private static List<PlayerSetting> ExtractPlayerlistFromLoadedData(SaveData data)
        {
			List<PlayerSetting> playerList = new();
			foreach(DbPlayer p in data.Players)
			{
				PlayerSetting playerSetting = new(
					p.Name,
					GetDiceTypeFromKey(p.Type),
					GetSelectorTypeFromKey(p.Type)
					);
				playerList.Add(playerSetting);
			}
			return playerList;
        }

        private static IDice GetDiceTypeFromKey(int i)
		{
			switch (i)
			{
				case 0: return (IDice)new AISelector();
				case 1: return (IDice)new ConsoleSelector();
				default: throw new NotImplementedException("Player type not implemented in load function.");
			}
		}

        private static ISelector GetSelectorTypeFromKey(int i)
        {
            switch (i)
            {
				case 0: return (ISelector)new AIDice();
				case 1: return (ISelector)new ConsoleDice();
				default: throw new NotImplementedException("Player type not implemented in load function.");
            }
        }
    }
}
