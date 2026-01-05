using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Entrada_Inventario_PA1.Model;

public class EntradaDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    public int entradaId { get; set; }
    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    public int ProductoId { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "La Cantidad no puede ser negativa")]
    public int Cantidad { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "El Precio no puede ser negativo")]
    public decimal Costo { get; set; }
    public virtual Entrada Entrada{ get; set; }
    public virtual Producto Producto { get; set; }
}

