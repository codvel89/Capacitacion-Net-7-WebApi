using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Modelos;


[Index(nameof(Nombre), nameof(Seccion), IsUnique = true)]
public class Grado
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public required string Nombre { get; set; }

    [Required]
    [StringLength(1, MinimumLength = 1)]
    public required string Seccion { get; set; }

    [JsonIgnore]
    public List<EstudianteDeGrado>? EstudiantesPorAula { get; set; }

}