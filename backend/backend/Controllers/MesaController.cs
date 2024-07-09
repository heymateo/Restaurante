using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class MesaController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public MesaController(BackendDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            return await _context.Mesa.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            return mesa;
        }

        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(Mesa mesa)
        {
            _context.Mesa.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesa", new { id = mesa.Id_Mesa }, mesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, [FromBody] Mesa mesa)
        {
            if (id != mesa.Id_Mesa)
            {
                return NotFound();
            }

            _context.Mesa.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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

        private bool MesaExists(int id)
        {
            return _context.Mesa.Any(a => a.Id_Mesa == id);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateMesa(int id)
        {
            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            mesa.Activa = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("GetMesas");
        }
    }
}
