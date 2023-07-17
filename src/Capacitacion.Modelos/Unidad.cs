using System.ComponentModel.DataAnnotations;

namespace Capacitacion.Modelos;

public class Unidad
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100, MinimumLength = 3)]
    public required string Nombre { get; set; }

    [Range(2024, 2050)]
    public int Ciclo { get; set; }

}