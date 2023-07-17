using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.Modelos;

public class Zona
{
    [Key]
    public int Id { get; set; }

    public int Ciclo { get; set; }

    [ForeignKey(nameof(Materia))]
    public int MateriaId { get; set; }

    [JsonIgnore]
    public Materia? Materia { get; set; }

    public TipoZona Tipo { get; set; }
    
    [DataType("DECIMAL(5,2)")]
    public decimal Valor { get; set; }
}