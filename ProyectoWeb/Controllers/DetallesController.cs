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
    [Authorize(Roles = "1")]
    public class DetallesController : Controller
    {
        private readonly ProyectoWebContext _context;

        public DetallesController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: Detalles
        public async Task<IActionResult> Index()
        {
              return _context.Detalles != null ? 
                          View(await _context.Detalles.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.Detalles'  is null.");
        }

        // GET: Detalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalles == null)
            {
                return NotFound();
            }

            var detalles = await _context.Detalles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalles == null)
            {
                return NotFound();
            }

            return View(detalles);
        }

        // GET: Detalles/Create
        public IActionResult Create()
        {
            ViewData["IdEncabezado"] = new SelectList(_context.Encabezados, "Id", "Id");
            ViewData["IdLectura"] = new SelectList(_context.Lecturas, "Id", "Id");
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id");
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEncabezado,IdLectura,IdTarifa,Consumo,Subtotal,FacturasPendientes,Total,EstadoDetalle")] Detalles detalles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalles);
        }

        // GET: Detalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["IdEncabezado"] = new SelectList(_context.Encabezados, "Id", "Id");
            ViewData["IdLectura"] = new SelectList(_context.Lecturas, "Id", "Id");
            ViewData["IdTarifa"] = new SelectList(_context.Tarifas, "Id", "Id");
            if (id == null || _context.Detalles == null)
            {
                return NotFound();
            }

            var detalles = await _context.Detalles.FindAsync(id);
            if (detalles == null)
            {
                return NotFound();
            }
            return View(detalles);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEncabezado,IdLectura,IdTarifa,Consumo,Subtotal,FacturasPendientes,Total,EstadoDetalle")] Detalles detalles)
        {
            if (id != detalles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesExists(detalles.Id))
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
            return View(detalles);
        }

        // GET: Detalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalles == null)
            {
                return NotFound();
            }

            var detalles = await _context.Detalles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalles == null)
            {
                return NotFound();
            }

            return View(detalles);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalles == null)
            {
                return Problem("Entity set 'ProyectoWebContext.Detalles'  is null.");
            }
            var detalles = await _context.Detalles.FindAsync(id);
            if (detalles != null)
            {
                _context.Detalles.Remove(detalles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesExists(int id)
        {
          return (_context.Detalles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
