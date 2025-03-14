using APICasamento.Entities;
using APICasamento_Teste.Entities;
using Microsoft.EntityFrameworkCore;

public class SQLiteServerContext : DbContext
{
    public SQLiteServerContext(DbContextOptions<SQLiteServerContext> options) : base(options) { } 

    public DbSet<Presente> Presentes { get; set; }
    public DbSet<Formulario> Formulario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/db_casamentomn.db");
    }
}
