using AtletaApi.Models;
using AtletaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtletaBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AtletaRecordController : ControllerBase
{
    public AtletaRecordController(ApplicationDbContext db) => 
        this.db = db;
        
    // GET: api/AtletaRecord/5
    [HttpGet("{id}")]
    public ActionResult<AtletaRecord> GetId(string id)
    {
        var obj = db.AtletasRecords.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum record com o identificador informado.");

        return obj;
    }

    // GET: api/mestre/AtletaRecord/5
    [HttpGet("mestre/{id}")]
    public ActionResult<IEnumerable<AtletaRecord>> GetIdMestre(string id)
    {
        var objetos = db.AtletasRecords.Where(x => x.AtletaId == id);

        if (objetos == null)
            return NotFound("Não foi encontrado nenhum record para o atleta informado.");

        return objetos.ToArray();
    }

    // POST: api/AtletaRecord
    [HttpPost]
    public ActionResult<AtletaRecord> Post(AtletaRecord obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        db.AtletasRecords.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // PUT: api/AtletaRecord/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, AtletaRecord obj)
    {
        if (id != obj.Id)
            return BadRequest("O identificador informado difere do identificador do objeto");

        db.AtletasRecords.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/AtletaRecord/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.AtletasRecords == null)
            return NotFound("Nenhum record cadastrado.");

        var obj = db.AtletasRecords.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("Não foi encontrado nenhum record com o identificador informado.");

        db.AtletasRecords.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
