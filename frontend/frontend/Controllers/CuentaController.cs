using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frontend.Models;

namespace frontend.Controllers
{
    public class CuentaController : Controller
    {
        private readonly FrontendDbContext _context;

        public CuentaController(FrontendDbContext context)
        {
            _context = context;
        }

        // GET: Cuenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuenta.ToListAsync());
        }

        // GET: Cuenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaModel = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id_Cuenta == id);
            if (cuentaModel == null)
            {
                return NotFound();
            }

            return View(cuentaModel);
        }

        // GET: Cuenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Cuenta,Id_Cliente,Id_Orden,Total,Cancelado")] CuentaModel cuentaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuentaModel);
        }

        // GET: Cuenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaModel = await _context.Cuenta.FindAsync(id);
            if (cuentaModel == null)
            {
                return NotFound();
            }
            return View(cuentaModel);
        }

        // POST: Cuenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Cuenta,Id_Cliente,Id_Orden,Total,Cancelado")] CuentaModel cuentaModel)
        {
            if (id != cuentaModel.Id_Cuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaModelExists(cuentaModel.Id_Cuenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cuentaModel);
        }

        // GET: Cuenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentaModel = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id_Cuenta == id);
            if (cuentaModel == null)
            {
                return NotFound();
            }

            return View(cuentaModel);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentaModel = await _context.Cuenta.FindAsync(id);
            if (cuentaModel != null)
            {
                _context.Cuenta.Remove(cuentaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaModelExists(int id)
        {
            return _context.Cuenta.Any(e => e.Id_Cuenta == id);
        }
    }
}
