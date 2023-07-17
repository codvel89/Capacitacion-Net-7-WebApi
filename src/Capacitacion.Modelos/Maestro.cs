using System.ComponentModel.DataAnnotations;

namespace Capacitacion.Modelos;

public class Maestro
{
    [Key]
    public int Id { get; set; }

    [StringLength(150, MinimumLength = 5)]
    public required string Name { get; set; }

}