using AtletaApi.Models;
using AtletaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtletaBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AtletaController : ControllerBase
{
    public AtletaController(ApplicationDbContext db) => 
        this.db = db;
        
    // GET: api/Atleta
    [HttpGet]
    public ActionResult<IEnumerable<Atleta>> Get()
    {
        if (db.Atletas == null)
            return NotFound("Nenhum atleta cadastrado.");

        return db.Atletas;
    }

    // GET: api/Atleta/5
    [HttpGet("{id}")]
    public ActionResult<Atleta> GetId(string id)
    {
        var obj = db.Atletas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum atleta com o identificador informado.");

        return obj;
    }

    // POST: api/Atleta
    [HttpPost]
    public ActionResult<Atleta> Post(Atleta obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        db.Atletas.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // PUT: api/Atleta/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Atleta obj)
    {
        if (id != obj.Id)
            return BadRequest("O identificador informado difere do identificador do objeto");
        
        db.Atletas.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Atleta/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Atletas == null)
            return NotFound("Nenhum atleta cadastrado.");

        var obj = db.Atletas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum atleta com o identificador informado.");

        db.Atletas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
