using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Contexts;

[Route("api/[controller]")]
[ApiController]
public class AsignacionsController : ControllerBase
{
    private readonly AplicationDbContext _context;
    public AsignacionsController(AplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Asignacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asignacion>>> GetAsignacion()
    {
        return await _context.Asignacions.ToListAsync();
    }

    // GET: api/Asignacion/5
    [HttpGet("{asignacionid}")]
    public async Task<ActionResult<Asignacion>> GetAsignacion(int asignacionid)
    {
        var asignacion = await _context.Asignacions.FindAsync(asignacionid);

        if (asignacion == null)
        {
            return NotFound();
        }

        return asignacion;
    }

    // PUT: api/Asignacion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{asignacionid}")]
    public async Task<IActionResult> PutAsignacion(int? asignacionid, Asignacion asignacion)
    {
        if (asignacionid != asignacion.AsignacionId)
        {
            return BadRequest();
        }

        _context.Entry(asignacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AsignacionExists(asignacionid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Asignacion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Asignacion>> PostAsignacion(Asignacion asignacion)
    {
        _context.Asignacions.Add(asignacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAsignacion", new { asignacionid = asignacion.AsignacionId }, asignacion);
    }

    // DELETE: api/Asignacion/5
    [HttpDelete("{asignacionid}")]
    public async Task<IActionResult> DeleteAsignacion(int? asignacionid)
    {
        var asignacion = await _context.Asignacions.FindAsync(asignacionid);
        if (asignacion == null)
        {
            return NotFound();
        }

        _context.Asignacions.Remove(asignacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AsignacionExists(int? asignacionid)
    {
        return _context.Asignacions.Any(e => e.AsignacionId == asignacionid);
    }
}
