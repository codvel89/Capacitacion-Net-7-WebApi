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
    public ActionResult<Grado> PostAula([FromBody] Grado grado)
    {

        db.Grados.Add(grado);
        db.SaveChanges();
        return Ok(grado);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Grado> PutAula([FromRoute] int Id, [FromBody] Grado grado)
    {

        if(!db.Grados.Any(x => x.Id == Id))
            return NoContent();

        grado.Id = Id;
        db.Grados.Entry(grado).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(grado);
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
    public ActionResult ListadoDeEstudiantePorGrado([FromRoute] int Id)
    {

        if(!db.Grados.Any(x => x.Id == Id))
            return NoContent();

        List<Estudiante> estudiantes = db.EstudiantesPorGrado.Include(x => x.Grado).Include(x => x.Estudiante).Where(x => x.Grado!.Id == Id).Select(x => x.Estudiante).ToList()!;

        return Ok(estudiantes);
    }

    [HttpPost]
    [Route("{Id:int}/Estudiantes/{EstudianteId:int}")]
    public ActionResult AgregarEstudianteAgrado([FromRoute] int Id, [FromRoute] int EstudianteId)
    {

        if(!db.Grados.Any(x => x.Id == Id))
            return NoContent();
        
        if(!db.Estudiantes.Any(x => x.Id == Id))
            return NoContent();

        EstudianteDeGrado relacion = new(){
            GradoId = Id,
            EstudianteId = EstudianteId,
            CicloEscolar = DateTime.Now.Year
        };

        db.EstudiantesPorGrado.Add(relacion);
        db.SaveChanges();

        return Ok();
    }


}