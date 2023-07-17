using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class Aula
{
    [Key]
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 5)]
    public required string Nombre { get; set; }

    [JsonIgnore]
    public List<Estudiante>? Estudiantes { get; set; }


}