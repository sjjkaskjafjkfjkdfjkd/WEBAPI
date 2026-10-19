using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Contexts;

[Route("api/[controller]")]
[ApiController]
public class EstudiantesController : ControllerBase
{
    private readonly AplicationDbContext _context;
    public EstudiantesController(AplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Estudiante
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiante()
    {
        return await _context.Estudiante.ToListAsync();
    }

    // GET: api/Estudiante/5
    [HttpGet("{estudianteid}")]
    public async Task<ActionResult<Estudiante>> GetEstudiante(int estudianteid)
    {
        var estudiante = await _context.Estudiante.FindAsync(estudianteid);

        if (estudiante == null)
        {
            return NotFound();
        }

        return estudiante;
    }

    // PUT: api/Estudiante/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{estudianteid}")]
    public async Task<IActionResult> PutEstudiante(int? estudianteid, Estudiante estudiante)
    {
        if (estudianteid != estudiante.EstudianteId)
        {
            return BadRequest();
        }

        _context.Entry(estudiante).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstudianteExists(estudianteid))
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

    // POST: api/Estudiante
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
    {
        _context.Estudiante.Add(estudiante);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEstudiante", new { estudianteid = estudiante.EstudianteId }, estudiante);
    }

    // DELETE: api/Estudiante/5
    [HttpDelete("{estudianteid}")]
    public async Task<IActionResult> DeleteEstudiante(int? estudianteid)
    {
        var estudiante = await _context.Estudiante.FindAsync(estudianteid);
        if (estudiante == null)
        {
            return NotFound();
        }

        _context.Estudiante.Remove(estudiante);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EstudianteExists(int? estudianteid)
    {
        return _context.Estudiante.Any(e => e.EstudianteId == estudianteid);
    }
}
