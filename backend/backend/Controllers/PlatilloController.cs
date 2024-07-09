using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public PlatilloController(BackendDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platillo>>> GetPlatillos()
        {
            return await _context.Platillo.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Platillo>> GetPlatillo(int id)
        {
            var platillo = await _context.Platillo.FindAsync(id);
            if (platillo == null)
            {
                return NotFound();
            }
            return platillo;
        }

        [HttpPost]
        public async Task<ActionResult<Platillo>> PostPlatillo(Platillo platillo)
        {
            _context.Platillo.Add(platillo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatillo", new { id = platillo.Id_Platillo }, platillo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatillo(int id, [FromBody] Platillo platillo)
        {
            if (id != platillo.Id_Platillo)
            {
                return BadRequest();
            }

            _context.Entry(platillo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatilloExist(id))
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

        private bool PlatilloExist(int id)
        {
            return _context.Platillo.Any(e => e.Id_Platillo == id);
        }

    }
}
