using GameEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace GameEngine.Data
{
    class LudoContext : DbContext
    {
        public DbSet<SaveData> Save { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LudoSaves;");
        }
    }
}
