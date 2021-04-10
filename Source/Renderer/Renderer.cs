using GameEngine;
using GameEngine.Models;
using GameEngine.Dice;
using GameEngine.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Renderer
{
    public class ConsoleRenderer
    {
        public Engine Engine { get; set; }
        public ConsoleRenderer Setup()
        {
            Console.WriteLine("Please enter how many players would like to play.");
            //var roll = new Random();
            int players = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many of those are going to be AI-players?");
            int ai = Convert.ToInt32(Console.ReadLine());
            if (ai <= players)
            {
                List<PlayerSetting> playerList = new();
                for (int i = 0; i < players-ai; i++)
                {
                    Console.WriteLine($"Please enter the name for player {i}");
                    playerList.Add(new(Console.ReadLine(), new ConsoleDice(), new ConsoleSelector()));
                }
                for (int i = players-ai; i < ai; i++)
                {
                    playerList.Add(new(i.ToString(), new AIDice(), new AISelector()));
                }
                Engine = new Engine(new GameSettings(playerList));
                return this;
            }
            throw new Exception("Invalid number of AI players");
        }
        public ConsoleRenderer Start()
        {
            var t = new Thread(() => Engine.StartGame());
            t.Start();
            Console.WriteLine("Thread started.");
            //Thread.Sleep(1000);
            //while (Engine.State.GameHasNoWinner)
            //{
            //    string boardAsString = "";
            //    foreach (Square s in Engine.State.Board.MainBoard)
            //    {
            //        boardAsString += "_";
            //    }
            //    foreach (Piece p in Engine.State.Board.Pieces)
            //    {
            //        if (p.PiecePosition >= 0)
            //        {
            //            switch (boardAsString[p.PiecePosition])
            //            {
            //                case '_':
            //                    char[] array = boardAsString.ToCharArray();
            //                    array[p.PiecePosition] = '1';
            //                    boardAsString = array.ToString();
            //                    break;
            //                default:
            //                    char[] carray = boardAsString.ToCharArray();
            //                    int value = carray[p.PiecePosition];
            //                    value++;
            //                    carray[p.PiecePosition] = Convert.ToChar(value);
            //                    boardAsString = carray.ToString();
            //                    break;
            //            }
            //        }
            //    }
            //    Console.WriteLine(boardAsString);
            //}
            return this;
        }
    }
}
