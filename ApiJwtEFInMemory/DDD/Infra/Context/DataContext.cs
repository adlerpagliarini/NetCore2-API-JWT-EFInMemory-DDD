using ApiJwtEFInMemory.DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtEFInMemory.DDD.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.CodigoBarras);
            modelBuilder.Entity<Usuario>().HasKey(u => u.ID);
        }
    }
}
