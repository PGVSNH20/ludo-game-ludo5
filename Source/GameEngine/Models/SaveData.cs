using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Models
{
    public class SaveData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Boardsize { get; set; }
        public List<DbPlayer> Players { get; set; }
        public List<Turn> ExecutedTurns { get; set; }
        public SaveData(int boardSize, List<DbPlayer> players, List<Turn> executedTurns)
        {
            Boardsize = boardSize;
            Players = players;
            ExecutedTurns = executedTurns;
        }
        public SaveData()
        {

        }
    }
}
