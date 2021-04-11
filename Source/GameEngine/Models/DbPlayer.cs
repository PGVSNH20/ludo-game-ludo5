using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine.Models
{
    public class DbPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DbPlayerId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        // Type refers to AI (0), Console user (1) or other (not implemented, higher values)
        // All other data can be calculated at load or during replay.
        public DbPlayer(int id, string name, int type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
