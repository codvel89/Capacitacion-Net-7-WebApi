using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Capacitacion.Modelos;

public class EstudiantePorGrado
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Grado))]
    public int GradoId { get; set; }

    [JsonIgnore]
    public Grado? Grado { get; set; }

    [ForeignKey(nameof(Estudiante))]
    public int EstudianteId { get; set; }
    public Estudiante? Estudiante { get; set; }

    public int CicloEscolar { get; set; }


}