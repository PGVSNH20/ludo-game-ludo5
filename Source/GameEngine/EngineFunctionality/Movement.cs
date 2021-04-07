using GameEngine.Classes;
using System;
using System.Collections.Generic;

namespace GameEngine.EngineFunctionality
{
	public static class Movement
    {
		public static Turn CheckIfValidSelection(Turn currentTurn, List<int> legalPieces)
		{
			try
			{
				int input = Convert.ToInt32(Console.ReadLine());
				if (legalPieces.Contains(input))
				{
					currentTurn.PieceID = input;
					return currentTurn;
				}
				Console.WriteLine("Invalid entry");
				PrintLegalMoves(legalPieces);
				return CheckIfValidSelection(currentTurn, legalPieces);

			}
			catch
			{
				Console.WriteLine("Invalid entry");
				return CheckIfValidSelection(currentTurn, legalPieces);
			}
		}

		public static List<int> ListLegalMoves(int roll, Gamestate state)
		{
			List<Piece> pieces = PlayerFunctions.GetActivePlayersPieces(state);
			List<int> listOfMoveablesIds = new();
			foreach (Piece p in pieces)
			{
				if (CheckIfPieceCanMove(roll, p, state)) listOfMoveablesIds.Add(p.HiddenID);
			}
			return listOfMoveablesIds;
		}

		public static bool AreThereLegalMoves(int roll, Gamestate state)
		{
			List<Piece> activePlayerPieces = PlayerFunctions.GetActivePlayersPieces(state);
			foreach (Piece p in activePlayerPieces)
			{
				if (CheckIfPieceCanMove(roll, p, state)) return true;
			}
			return false;
		}

		public static bool CheckIfPieceCanMove(int roll, Piece p, Gamestate state)
		{
			if (p.PiecePosition == -1) return roll == 6;
			if (p.PiecePosition == -2) return false;
			if (p.PiecePosition + roll <= state.Board.MainBoard.Count + 5) return true;
			return false;
		}
		public static void PrintLegalMoves(List<int> legalPieces)
		{
			Console.WriteLine("Please select which piece to move.");
			foreach (int i in legalPieces)
			{
				Console.WriteLine($"Piece {i}");
			}
		}

	}
}
