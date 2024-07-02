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
        modelBuilder.Entity<Usuario>().HasKey(a => a.Id);
        modelBuilder.Entity<Categoria>().HasKey(a => a.Id);
        modelBuilder.Entity<Avaliacao>().HasKey(a => a.Id);

        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Categoria)
            .WithMany(u => u.Avaliacoes)
            .HasForeignKey(a => a.IdCategoria)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Categoria>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.Categorias)
            .HasForeignKey(c => c.IdUsuario);

        base.OnModelCreating(modelBuilder);
    }
}