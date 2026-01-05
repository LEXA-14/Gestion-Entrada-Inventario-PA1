
using Gestion_Entrada_Inventario_PA1.Data;
using Gestion_Entrada_Inventario_PA1.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Gestion_Entrada_Inventario_PA1.Servicess;

public class ProductoServices(IDbContextFactory<Contexto> dbFactory)
{

    public async Task<bool> Guardar(Producto producto)
    {
        if (producto.ProductoId == 0)
        {
            producto.Fecha = DateTime.Now;
            return await Insertar(producto);
        }
        else
        {
            return await Modificar(producto);
        }

    }

    private async Task<bool> Insertar(Producto producto)
    {
        using var contexto = await dbFactory.CreateDbContextAsync();
        contexto.Add(producto);
        return await contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Modificar(Producto producto)
    {
        using var contexto = await dbFactory.CreateDbContextAsync();
        contexto.Update(producto);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminar(int id)
    {
        using var contexto = await dbFactory.CreateDbContextAsync();

        var categoria = await contexto.Producto.FirstOrDefaultAsync(c => c.ProductoId == id);
        if (categoria == null)
            return false;

        contexto.Producto.Remove(categoria);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<Producto?> Buscar(int id)
    {
        using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Producto
            .FirstOrDefaultAsync(c => c.ProductoId == id);
    }
  
    public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        return await contexto.Producto.Include(d => d.detalle)
            .Where(criterio)
            .ToListAsync();
    }
}