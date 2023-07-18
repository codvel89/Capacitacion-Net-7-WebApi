using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly ColegioDbContext db;

    public DatabaseController(ColegioDbContext db)
    {
        this.db = db;
    }


    
    [HttpPost]
    public ActionResult CrearBaseDatos()
    {

        if(db.Database.CanConnect())
        {
            db.Database.EnsureDeleted();
        }

        db.Database.EnsureCreated();

        db.Database.BeginTransaction();

        Estudiante estudiante = new()
        {
            Nombre = "Abner Velasco",
            Email = "codvel90@gmail.com",
            Edad = 13
        };

        db.Estudiantes.Add(estudiante);

        Grado grado = new()
        {
            Nombre = "Primero Básico",
            Seccion = "A"
        };

        db.Grados.Add(grado);
        db.SaveChanges();

        db.Database.CommitTransaction();


        return Ok();
    }
     
}
