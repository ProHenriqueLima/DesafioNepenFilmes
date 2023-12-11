using FilmeNepenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FilmeNepenApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento e configuração de entidades aqui
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Admin",
                    Ativo = 1,
                    Cargo = "admin",
                    Password = "cbfdac6008f9cab4083784cbd1874f76618d2a97d30d8f00c39c6729e8f6d56d",
                    Username = "admin",
                }
            );
        }
    }
}