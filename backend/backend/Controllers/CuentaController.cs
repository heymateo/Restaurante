using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public CuentaController(BackendDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
        {
            return await _context.Cuenta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetCuenta(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return cuenta;
        }

        [HttpPost]
        public async Task<ActionResult<Cuenta>> PostCuenta(Cuenta cuenta)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var orden = await _context.Orden
                    .Include(x => x.DetalleOrden)
                        .ThenInclude(d => d.Platillo) // Incluir la referencia al platillo
                    .Include(o => o.DetalleOrden)
                        .ThenInclude(b => b.Bebida)
                    .FirstOrDefaultAsync(o => o.Id_Orden == cuenta.Id_Orden);

                    if (orden == null)
                    {
                        return NotFound("Orden no encontrada");
                    }

                    decimal total = 0;
                    foreach (var detalle in orden.DetalleOrdenes)
                    {
                        total += (detalle.Cantidad_Platillo * detalle.Platillo.Precio) +
                                 (detalle.Cantidad_Bebida * detalle.Bebida.Precio);
                    }

                    cuenta.Total = total;

                    _context.Cuenta.Add(cuenta);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetCuenta", new { id = cuenta.Id_Cuenta }, cuenta);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(int id, [FromBody] Cuenta cuenta)
        {
            if (id != cuenta.Id_Cuenta)
            {
                return BadRequest();
            }

            _context.Entry(cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
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

        private bool CuentaExists(int id)
        {
            return _context.Cliente.Any(e => e.Id_Cliente == id);
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelCuenta(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            cuenta.Cancelado = false;
            await _context.SaveChangesAsync();

            return RedirectToAction("GetCuentas");
        }
    }
}
