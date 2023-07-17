using System.ComponentModel.DataAnnotations;

namespace Capacitacion.Modelos;

public class Materia
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    public required string Nombre { get; set; }
    public Nivel Nivel { get; set; }
}