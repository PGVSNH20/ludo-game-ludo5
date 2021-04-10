using GameEngine.Dice;
using GameEngine.Models;
using GameEngine.Selectors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Data
{
    class LudoContext : DbContext
    {
        public DbSet<SaveData> Save { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LudoSaves;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AIDice>();
            builder.Entity<ConsoleDice>();
            builder.Entity<AISelector>();
            builder.Entity<ConsoleSelector>();
            base.OnModelCreating(builder);

        }
    }
}
