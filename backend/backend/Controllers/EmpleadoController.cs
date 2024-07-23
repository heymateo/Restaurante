using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public EmpleadoController(BackendDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleado.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id_Empleado }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id_Empleado)
            {
                return NotFound();
            }

            _context.Empleado.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(a => a.Id_Empleado == id);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateEmpleado(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Activo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
