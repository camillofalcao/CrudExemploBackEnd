using AtletaApi.Models;
using AtletaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TreinadorBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TreinadorController : ControllerBase
{
    public TreinadorController(ApplicationDbContext db) => 
        this.db = db;

    // GET: api/Treinador
    [HttpGet]
    public ActionResult<IEnumerable<Treinador>> Get()
    {
        if (db.Treinadores == null)
            return NotFound("Nenhum treinador cadastrado.");

        return db.Treinadores;
    }

    // GET: api/Treinador/5
    [HttpGet("{id}")]
    public ActionResult<Treinador> GetId(string id)
    {
        var obj = db.Treinadores.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum treinador com o identificador informado.");

        return obj;
    }

    // POST: api/Treinador
    [HttpPost]
    public ActionResult<Treinador> Post(Treinador obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        db.Treinadores.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // PUT: api/Treinador/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Treinador obj)
    {
        if (id != obj.Id)
            return BadRequest("O identificador informado difere do identificador do objeto");

        db.Treinadores.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Treinador/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Treinadores == null)
            return NotFound("Nenhum treinador cadastrado.");

        var obj = db.Treinadores.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum treinador com o identificador informado.");

        db.Treinadores.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
