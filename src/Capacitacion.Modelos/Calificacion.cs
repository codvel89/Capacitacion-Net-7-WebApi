using System.ComponentModel.DataAnnotations;

namespace Capacitacion.Modelos;

public class Calificacion
{
    
    [Key]
    public int Id { get; set; }
    public int GradoId { get; set; }
    public int UnidadId { get; set; }
    public int MateriaId { get; set; }

}