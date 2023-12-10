using FilmeNepenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeNepenApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
