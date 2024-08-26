using backend.Models;
using frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public OrdenController(BackendDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            return await _context.Orden.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(OrdenDTO ordenDTO)
        {
            var orden = new Orden
            {
                Fecha = ordenDTO.Fecha,
                Hora = ordenDTO.Hora,
                Cantidad_Personas = ordenDTO.Cantidad_Personas,
                Id_Mesa = ordenDTO.Id_Mesa,
                // Otros campos se pueden establecer si son necesarios y manejados automáticamente
            };

            try
            {
                _context.Orden.Add(orden);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOrden", new { id = orden.Id_Orden }, orden);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, [FromBody] OrdenDTO ordenDTO)
        {
            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            orden.Fecha = ordenDTO.Fecha;
            orden.Hora = ordenDTO.Hora;
            orden.Cantidad_Personas = ordenDTO.Cantidad_Personas;
            orden.Id_Mesa = ordenDTO.Id_Mesa;
            // Otros campos se pueden actualizar si son necesarios

            try
            {
                _context.Entry(orden).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
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

        private bool OrdenExists(int id)
        {
            return _context.Orden.Any(a => a.Id_Orden == id);
        }
    }
}
