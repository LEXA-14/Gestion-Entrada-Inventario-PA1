using Gestion_Entrada_Inventario_PA1.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Entrada_Inventario_PA1.Data;

public class Contexto(DbContextOptions<Contexto> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Producto> Producto { get; set; }

    public DbSet<EntradaDetalle> EntradaDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EntradaDetalle>()
            .HasOne(d => d.Producto)
            .WithMany(p => p.detalle)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
