using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class MateriaDeGrado
{
    public int Id { get; set; }
    
    [ForeignKey(nameof(Grado))]
    public int GradoId { get; set; }

    [JsonIgnore]
    public virtual Grado? Grado { get; set; }

    [ForeignKey(nameof(Materia))]
    public int MateriaId { get; set; }

    [JsonIgnore]
    public virtual Materia? Materia { get; set; }
}