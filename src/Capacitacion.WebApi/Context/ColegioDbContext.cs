using Capacitacion.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Context;

public class ColegioDbContext : DbContext
{


    public required DbSet<Estudiante> Estudiantes { get; set; }
    public required DbSet<Grado> Grados { get; set; }
    public required DbSet<Maestro> Maestros { get; set; }

    public ColegioDbContext(DbContextOptions options) : base(options)
    {
        
    }



}