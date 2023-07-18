using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Modelos;

[Index(nameof(MaestroId), nameof(GradoId), IsUnique = true)]
public class MaestroDeGrado
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Maestro))]
    public int MaestroId { get; set; }

    [JsonIgnore]
    public virtual Maestro? Maestro { get; set; }

    [ForeignKey(nameof(Grado))]
    public int GradoId { get; set; }

    [JsonIgnore]
    public virtual Grado? Grado { get; set; }

}