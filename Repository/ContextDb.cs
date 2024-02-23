using Microsoft.EntityFrameworkCore;
using SistemaFinch.Repository.Models;

namespace SistemaFinch.Repository
{
    public class ContextDb(string conn) : DbContext
    {
        private readonly string _connection = conn;

        public DbSet<Login> Login { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer(_connection); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().ToTable("Login");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
            modelBuilder.Entity<Produto>().ToTable("Produto");
        }


    }


}
