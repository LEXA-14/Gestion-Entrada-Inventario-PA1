using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Entrada_Inventario_PA1.Model;

public class Producto
    {
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    public string Descripcion { get; set; } = string.Empty;
    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
 
    public decimal Precio { get; set; }
    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Costo { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser menor que cero")]
    public int Existencia { get; set; }

    public DateTime Fecha { get; set; }= DateTime.Now;
    public virtual ICollection<EntradaDetalle> detalle { get; set; } = new List<EntradaDetalle>();
}

