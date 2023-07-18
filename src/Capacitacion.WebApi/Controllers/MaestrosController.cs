using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class MaestrosController : ControllerBase
{
    private readonly ColegioDbContext db;

    public MaestrosController(ColegioDbContext db)
    {
        this.db = db;
    }


    [HttpGet]
    public ActionResult<List<Maestro>> GetAulas()
    {
        var aulas = db.Maestros.ToList();
        return Ok(aulas);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public ActionResult<Maestro> GetAula([FromRoute] int Id)
    {
        var aula = db.Maestros.Find(Id);
        return Ok(aula);
    }

    [HttpPost]
    public ActionResult<Maestro> PostAula([FromBody] Maestro maestro)
    {

        db.Maestros.Add(maestro);
        db.SaveChanges();
        return Ok(maestro);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Maestro> PutAula([FromRoute] int Id, [FromBody] Maestro maestro)
    {

        if(!db.Maestros.Any(x => x.Id == Id))
            return NoContent();

        maestro.Id = Id;
        db.Maestros.Entry(maestro).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(maestro);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public ActionResult DeleteAula([FromRoute] int Id)
    {
        if(!db.Maestros.Any(x => x.Id == Id))
            return NoContent();

        var aula = db.Maestros.Find(Id)!;

        db.Maestros.Remove(aula);
        db.SaveChanges();

        return Ok();
    }


}