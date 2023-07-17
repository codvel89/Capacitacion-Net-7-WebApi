using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class Materia
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    public required string Nombre { get; set; }



}