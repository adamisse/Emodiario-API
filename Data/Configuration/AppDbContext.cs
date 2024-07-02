using Emodiario.Models;
using Microsoft.EntityFrameworkCore;

namespace Emodiario.Data.Configuration;

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
        modelBuilder.Entity<Avaliacao>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Usuario)
            .WithMany(u => u.Avaliacoes)
            .HasForeignKey(a => a.IdUsuario);

        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Categoria)
            .WithMany()
            .HasForeignKey(a => a.IdCategoria);

        base.OnModelCreating(modelBuilder);
    }
}