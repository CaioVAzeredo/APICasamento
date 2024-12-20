﻿using APICasamento.Entities;
using Microsoft.EntityFrameworkCore;

namespace APICasamento.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        // Defina os DbSets para suas entidades
        public DbSet<Presente> Presente { get; set; } 
        public DbSet<Informacoes> Informacoes { get; set; }
        public DbSet<Formulario> Formulario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseMySql("Server=db-casamentomn.cnsyki4kwcga.us-east-1.rds.amazonaws.com;Database=db_casamentomn;User=admin;Password=matheusenadyr;",
                    new MySqlServerVersion(new Version(8, 0, 31)));
            }
        }
    }
}
