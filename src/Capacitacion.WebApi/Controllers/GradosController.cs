using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class GradosController : ControllerBase
{
    private readonly ColegioDbContext db;

    public GradosController(ColegioDbContext db)
    {
        this.db = db;
    }


    [HttpGet]
    public ActionResult<List<Grado>> GetAulas()
    {
        var aulas = db.Grados.ToList();
        return Ok(aulas);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public ActionResult<Grado> GetAula([FromRoute] int Id)
    {
        var aula = db.Grados.Find(Id);
        return Ok(aula);
    }

    [HttpPost]
    public ActionResult<Grado> PostAula([FromBody] Grado aula)
    {

        db.Grados.Add(aula);
        db.SaveChanges();
        return Ok(aula);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Grado> PutAula([FromRoute] int Id, [FromBody] Grado aula)
    {

        if(!db.Grados.Any(x => x.Id == Id))
            return NoContent();

        aula.Id = Id;
        db.Grados.Entry(aula).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(aula);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public ActionResult DeleteAula([FromRoute] int Id)
    {
        if(!db.Grados.Any(x => x.Id == Id))
            return NoContent();

        var aula = db.Grados.Find(Id)!;

        db.Grados.Remove(aula);
        db.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("{Id:int}/Estudiantes")]
    public ActionResult<List<Estudiante>> ObtenerEstudiantesDeAula([FromRoute] int Id)
    {
        var aula = db.Grados.Include(x => x.Estudiantes).Single(x => x.Id == Id)!;
        return Ok(aula.Estudiantes);
    }

}