using ProjetoAspNetCoreBasico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAspNetCoreBasico.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }  // Cria a tabela no banco

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
