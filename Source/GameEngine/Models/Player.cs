using GameEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace GameEngine.Models
{
    public class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool FinishedOrQuitTheGame { get; set; }
        public IDice Dice { get; set; }
        public ISelector Selector { get; set; }
        
        public Player(int id, String name, IDice dice)
        {
            Id = id;
            Name = name;
            Score = 0;
            Dice = dice;

           // ColorType som enum är bra för att t.ex. ColorType.Blue returnerar en etta.
           // Jag tror att Player borde ha en int, inte en ColorType, och att man sätter att public int Color = ColorType.Blue; (som exempel)
           // ...Men det känns som om jag får komma tillbaka till det senare.
           // Kanske borde vara att spelare har en ID som är av typ int, och att man använder en Dictionary<int, string> för att få ut färgen från ID:et
           // Inte för att man i logiken behöver få ut namnet på färgen när jag tänker efter, det är väl något för renderaren att ta hand om senare.
        }
        public Player(int id, PlayerSetting playerSetting)
        {
            Id = id;
            Name = playerSetting.Name;
            Dice = playerSetting.Dice;
            Score = 0;
            Selector = playerSetting.Selector;
        }

        public static List<Player> GeneratePlayers(List<PlayerSetting> players)
        {
            var list = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                list.Add(new Player(i, players[i]));
            }
            return list;

            /*
            while (Player[0] == "")
            {
                Console.WriteLine("You have to enter a name");
                Player[0] = Console.ReadLine();
            }*/

            //Do we need to clear the screen after the player enter the name?
            //Console.Clear();
        }
    }
}
