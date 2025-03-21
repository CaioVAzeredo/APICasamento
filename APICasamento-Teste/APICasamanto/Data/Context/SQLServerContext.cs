using APICasamanto.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APICasamanto.Data.Context
{
        public class SQLServerContext : DbContext
        {
            public SQLServerContext(DbContextOptions options) : base(options) { }
        public DbSet<Formulario> Formulario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
