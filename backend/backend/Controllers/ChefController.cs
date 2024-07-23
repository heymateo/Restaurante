using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public ChefController(BackendDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chef>>> GetChefs()
        {
            return await _context.Chef.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chef>> GetChef(int id)
        {
            var chef = await _context.Chef.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }

            return chef;
        }

        [HttpPost]
        public async Task<ActionResult<Chef>> PostChef(Chef chef)
        {
            _context.Chef.Add(chef);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChef", new { id = chef.Id_Chef }, chef);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChef(int id, [FromBody] Chef chef)
        {
            if (id != chef.Id_Chef)
            {
                return BadRequest();
            }

            _context.Entry(chef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChefExists(id))
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

        private bool ChefExists(int id)
        {
            return _context.Chef.Any(e => e.Id_Chef == id);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateChef(int id)
        {
            var chef = await _context.Chef.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }

            chef.Activo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
