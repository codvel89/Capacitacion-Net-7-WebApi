using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class EstudiantesController  : ControllerBase
{
    private readonly ColegioDbContext db;

    public EstudiantesController(ColegioDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult<List<Estudiante>> GetEstudiantes()
    {
        var Estudiantes = db.Estudiantes.ToList();
        return Ok(Estudiantes);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public ActionResult<Estudiante> GetEstudiante([FromRoute] int Id)
    {
        var Estudiante = db.Estudiantes.Find(Id);
        return Ok(Estudiante);
    }

    [HttpPost]
    public ActionResult<Estudiante> PostEstudiante([FromBody] Estudiante Estudiante)
    {

        db.Estudiantes.Add(Estudiante);
        db.SaveChanges();
        return Ok(Estudiante);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Estudiante> PutEstudiante([FromRoute] int Id, [FromBody] Estudiante Estudiante)
    {

        if(!db.Estudiantes.Any(x => x.Id == Id))
            return NoContent();

        Estudiante.Id = Id;
        db.Estudiantes.Entry(Estudiante).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(Estudiante);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public ActionResult DeleteEstudiante([FromRoute] int Id)
    {
        if(!db.Estudiantes.Any(x => x.Id == Id))
            return NoContent();

        var Estudiante = db.Estudiantes.Find(Id)!;

        db.Estudiantes.Remove(Estudiante);
        db.SaveChanges();

        return Ok();
    }



}