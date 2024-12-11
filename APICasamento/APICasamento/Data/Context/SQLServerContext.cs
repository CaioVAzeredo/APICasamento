using APICasamento.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        // Defina os DbSets para suas entidades
        public DbSet<Presente> Presente { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseMySql("Server=localhost;Database=ApiCasamento;User=root;Password=sua_senha;",
                    new MySqlServerVersion(new Version(8, 0, 31)));
            }
        }
    }
}
