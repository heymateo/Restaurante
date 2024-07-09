using backend.Models;
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
        public async Task<ActionResult<Orden>> PostOrden(Orden orden)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Orden.Add(orden);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return CreatedAtAction("GetOrden", new { id = orden.Id_Mesa }, orden);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, [FromBody] Orden orden)
        {
            if (id != orden.Id_Orden)
            {
                return NotFound();
            }

            _context.Orden.Entry(orden).State = EntityState.Modified;

            try
            {
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
