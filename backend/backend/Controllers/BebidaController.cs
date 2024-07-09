using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public BebidaController(BackendDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await _context.Bebida.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            var bebida = await _context.Bebida.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return bebida;
        }

        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            _context.Bebida.Add(bebida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBebida", new { id = bebida.Id_Bebida }, bebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBebida(int id, [FromBody] Bebida bebida)
        {
            if (id != bebida.Id_Bebida)
            {
                return BadRequest();
            }

            _context.Entry(bebida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BebidaExist(id))
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

        private bool BebidaExist(int id)
        {
            return _context.Bebida.Any(e => e.Id_Bebida == id);
        }

    }
}
