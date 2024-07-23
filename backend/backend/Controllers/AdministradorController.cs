using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly BackendDbContext _context;
        public AdministradorController(BackendDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdmins()
        {
            return await _context.Administrador.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdmin(int id)
        {
            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return admin;
        }

        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdmin(Administrador admin)
        {
            _context.Administrador.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Id_Administrador }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, [FromBody] Administrador admin)
        {
            if (id != admin.Id_Administrador)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        private bool AdminExists(int id)
        {
            return _context.Administrador.Any(e => e.Id_Administrador == id);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateAdmin(int id)
        {
            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            admin.Activo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
