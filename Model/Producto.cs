using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Entrada_Inventario_PA1.Model;

public class Producto
    {
    [Key]
    public int Productoid { get; set; }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    public string Descripcion { get; set; } = string.Empty;
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
    public double Precio { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser menor que cero")]
    public int Existencia { get; set; }

    [InverseProperty("Producto")]
    public ICollection<EntradaDetalle> detalle { get; set; }
}

