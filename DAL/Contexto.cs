using Gestion_Entrada_Inventario_PA1.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Entrada_Inventario_PA1.DAL;

public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Producto> Producto { get; set; }

    public DbSet<EntradaDetalle> EntradaDetalle { get; set; }
}
