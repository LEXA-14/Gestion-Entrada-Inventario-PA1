using Gestion_Entrada_Inventario_PA1.DAL;
using Gestion_Entrada_Inventario_PA1.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gestion_Entrada_Inventario_PA1.Servicess;

public class EntradaProductoServices(IDbContextFactory<Contexto> dbFactory)
{
    public async Task<bool> Guardar(Entrada entrada)
    {
        if (!await Existe(entrada.EntradaId))
        {
            return await Insertar(entrada);

        }
        else
        {
            return await Modificar(entrada);
        }
    }

    private async Task AfectarEntrada(EntradaDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        foreach (var item in detalle)
        {
            var producto = await contexto.Producto.SingleOrDefaultAsync(c => c.ProductoId == item.ProductoId);

            if (producto != null)
            {
                if (tipoOperacion == TipoOperacion.Suma)
                {
                    producto.Existencia += item.Cantidad;
                }
                else
                {
                    producto.Existencia -= item.Cantidad;
                }
            }
        }
        await contexto.SaveChangesAsync();
    }

    private async Task<bool> Modificar(Entrada entrada)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        var entradaOriginal = await contexto.Entrada.Include(d => d.detalle)
            .AsNoTracking().
            SingleOrDefaultAsync(p => p.EntradaId == entrada.EntradaId);

        if (entradaOriginal == null) return false;

        await AfectarEntrada(entradaOriginal.detalle.ToArray(), TipoOperacion.Suma);

        var detalleAnterior = await contexto.EntradaDetalle.Where(d => d.entradaId == entrada.EntradaId).ToListAsync();

        contexto.EntradaDetalle.RemoveRange(detalleAnterior);

        await AfectarEntrada(entrada.detalle.ToArray(), TipoOperacion.Resta);

        contexto.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;


    }

    private async Task<bool> Insertar(Entrada entrada)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        contexto.Add(entrada);
        await AfectarEntrada(entrada.detalle.ToArray(), TipoOperacion.Resta);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Existe(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();
        return await contexto.Entrada.AnyAsync(a => a.EntradaId == id);
    }
    //eliminar

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        var entrada = await contexto.Entrada.Include(d => d.detalle)
             .FirstOrDefaultAsync(e => e.EntradaId == id);

        if (entrada == null) return false;

        await AfectarEntrada(entrada.detalle.ToArray(), TipoOperacion.Suma);

        contexto.EntradaDetalle.RemoveRange(entrada.detalle);
        contexto.Entrada.Remove(entrada);

        return await contexto.SaveChangesAsync() > 0;

    }

    public async Task<Entrada?> BuscarId(int id)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        return await contexto.Entrada.Include(d => d.detalle).
            ThenInclude(c => c.producto).
            FirstOrDefaultAsync(p => p.EntradaId == id);
    }

    //Listar 

    public async Task<List<Entrada>> GetLista(Expression<Func<Entrada, bool>> criterio)
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        return await contexto.Entrada.Include(d => d.detalle).
            ThenInclude(c => c.producto)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Producto>> GetListaProductos()
    {
        await using var contexto = await dbFactory.CreateDbContextAsync();

        return await contexto.Producto.AsNoTracking().ToListAsync();

    }

    public enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }

}
