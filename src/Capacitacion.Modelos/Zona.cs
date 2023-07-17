using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Modelos;

public class Punteo
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Materia))]
    public int MateriaId { get; set; }

    [JsonIgnore]
    public Materia? Materia { get; set; }

    public TipoPunteo Tipo { get; set; }
    
    [DataType("DECIMAL(5,2)")]
    public decimal Valor { get; set; }
}