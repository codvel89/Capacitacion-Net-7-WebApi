using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class Calificacion
{
    
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Grado))]
    public int GradoId { get; set; }
    [JsonIgnore]
    public Grado? Grado { get; set; }

    [ForeignKey(nameof(Unidad))]
    public int UnidadId { get; set; }

    [JsonIgnore]
    public Unidad? Unidad { get; set; }
    
    [ForeignKey(nameof(Materia))]
    public int MateriaId { get; set; }
    
    [JsonIgnore]
    public Materia? Materia { get; set; }

}