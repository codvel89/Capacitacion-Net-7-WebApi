
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class Estudiante
{

    [Key]
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 5)]
    public required string Nombre { get; set; }
    public string? Email { get; set; }
    public int Edad { get; set; }


    [JsonIgnore]
    public List<EstudianteDeGrado>? EstudiantesPorAula { get; set; }

}
