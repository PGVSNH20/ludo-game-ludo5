using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GameEngine.Models
{
    public class SaveData
    {
        [Key]
        public int Id { get; set; }
        public GameSettings Settings { get; set; }
        public List<Turn> ExecutedTurns { get; set; }
    }
}
