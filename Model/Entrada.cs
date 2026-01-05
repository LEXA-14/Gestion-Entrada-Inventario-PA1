using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Entrada_Inventario_PA1.Model;

public class Entrada
{
    [Key]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "En este campo solo se permiten letras. ")]
    public string Concepto { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int Cantidad { get; set; }
    public decimal Total {  get; set; }
    public ICollection<EntradaDetalle> detalle { get; set; }=new List<EntradaDetalle>();

}

