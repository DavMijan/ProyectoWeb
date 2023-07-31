using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Data;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    [Authorize(Roles = "1,4" )]
    public class MedidoresController : Controller
    {
        private readonly ProyectoWebContext _context;

        public MedidoresController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: Medidores
        public async Task<IActionResult> Index()
        {
              return _context.Medidores != null ? 
                          View(await _context.Medidores.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.Medidores'  is null.");
        }

        // GET: Medidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medidores == null)
            {
                return NotFound();
            }

            var medidores = await _context.Medidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medidores == null)
            {
                return NotFound();
            }

            return View(medidores);
        }

        // GET: Medidores/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "NombreCliente");
            ViewData["IdTipoMedidor"] = new SelectList(_context.TiposMedidores, "Id", "TipoMedidor");
            return View();
        }

        // POST: Medidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nis,IdCliente,IdTipoMedidor,Ubicacion,EstadoMedidor")] Medidores medidores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medidores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medidores);
        }

        // GET: Medidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "NombreCliente");
            ViewData["IdTipoMedidor"] = new SelectList(_context.TiposMedidores, "Id", "TipoMedidor");
            if (id == null || _context.Medidores == null)
            {
                return NotFound();
            }

            var medidores = await _context.Medidores.FindAsync(id);
            if (medidores == null)
            {
                return NotFound();
            }
            return View(medidores);
        }

        // POST: Medidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nis,IdCliente,IdTipoMedidor,Ubicacion,EstadoMedidor")] Medidores medidores)
        {
            if (id != medidores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medidores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedidoresExists(medidores.Id))
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
            return View(medidores);
        }

        // GET: Medidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medidores == null)
            {
                return NotFound();
            }

            var medidores = await _context.Medidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medidores == null)
            {
                return NotFound();
            }

            return View(medidores);
        }

        // POST: Medidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medidores == null)
            {
                return Problem("Entity set 'ProyectoWebContext.Medidores'  is null.");
            }
            var medidores = await _context.Medidores.FindAsync(id);
            if (medidores != null)
            {
                _context.Medidores.Remove(medidores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedidoresExists(int id)
        {
          return (_context.Medidores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
