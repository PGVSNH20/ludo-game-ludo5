using GameEngine.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Piece> Pieces { get; set; }
        public int Id { get; set; }
        public Player(int i)
        {
           // ColorType som enum är bra för att t.ex. ColorType.Blue returnerar en etta.
           // Jag tror att Player borde ha en int, inte en ColorType, och att man sätter att public int Color = ColorType.Blue; (som exempel)
           // ...Men det känns som om jag får komma tillbaka till det senare.
           // Kanske borde vara att spelare har en ID som är av typ int, och att man använder en Dictionary<int, string> för att få ut färgen från ID:et
           // Inte för att man i logiken behöver få ut namnet på färgen när jag tänker efter, det är väl något för renderaren att ta hand om senare.
        }

        public static List<Player> GeneratePlayers(int players)
        {
            var list = new List<Player>();
            for (int i = 0; i < players; i++)
            {
                list.Add(new Player(i));
            }
            return list;
        }
    }
}
