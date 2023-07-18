using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class MateriasController : ControllerBase
{
    private readonly ColegioDbContext db;

    public MateriasController(ColegioDbContext db)
    {
        this.db = db;
    }


    [HttpGet]
    public ActionResult<List<Materia>> GetMaterias()
    {
        var Materias = db.Materias.ToList();
        return Ok(Materias);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public ActionResult<Materia> GetMateria([FromRoute] int Id)
    {
        var Materia = db.Materias.Find(Id);
        return Ok(Materia);
    }

    [HttpPost]
    public ActionResult<Materia> PostMateria([FromBody] Materia materia)
    {

        db.Materias.Add(materia);
        db.SaveChanges();
        return Ok(materia);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Materia> PutMateria([FromRoute] int Id, [FromBody] Materia materia)
    {

        if(!db.Materias.Any(x => x.Id == Id))
            return NoContent();

        materia.Id = Id;
        db.Materias.Entry(materia).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(materia);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public ActionResult DeleteMateria([FromRoute] int Id)
    {
        if(!db.Materias.Any(x => x.Id == Id))
            return NoContent();

        var Materia = db.Materias.Find(Id)!;

        db.Materias.Remove(Materia);
        db.SaveChanges();

        return Ok();
    }


}