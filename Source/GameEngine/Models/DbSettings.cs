using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Models
{
    public class DbSettings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BoardSize { get; set; }
        public DbSettings(int boardSize)
        {
            BoardSize = boardSize;
        }
    }
}
