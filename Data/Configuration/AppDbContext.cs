using Emodiario.Models;
using Microsoft.EntityFrameworkCore;

namespace Emodiario.Data.Configuration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias compostas, índices, etc.

            // Exemplo de configuração de chave primária composta para a entidade Review
            modelBuilder.Entity<Avaliacao>()
                .HasKey(a => new { a.IdUsuario, a.IdCategoria });
        }
    }
}