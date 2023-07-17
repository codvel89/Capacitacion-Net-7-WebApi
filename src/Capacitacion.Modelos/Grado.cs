using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Modelos;


[Index(nameof(Nombre), nameof(Seccion), nameof(Nivel), IsUnique = true)]
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
    public Nivel Nivel { get; set; }

    [JsonIgnore]
    public List<Estudiante>? Estudiantes { get; set; }

}