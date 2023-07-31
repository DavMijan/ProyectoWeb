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
    public class AlertasController : Controller
    {
        private readonly ProyectoWebContext _context;

        public AlertasController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: Alertas
        public async Task<IActionResult> Index()
        {
              return _context.Alertas != null ? 
                          View(await _context.Alertas.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.Alertas'  is null.");
        }

        // GET: Alertas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alertas == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertas == null)
            {
                return NotFound();
            }

            return View(alertas);
        }

        // GET: Alertas/Create
        public IActionResult Create()
        {
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Id");
            return View();
        }

        // POST: Alertas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMedidor,Alerta,EstadoAlerta")] Alertas alertas)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(alertas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alertas);
        }

        // GET: Alertas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Id");
            if (id == null || _context.Alertas == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas.FindAsync(id);
            if (alertas == null)
            {
                return NotFound();
            }
            return View(alertas);
        }

        // POST: Alertas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMedidor,Alerta,EstadoAlerta")] Alertas alertas)
        {
            if (id != alertas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertasExists(alertas.Id))
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
            return View(alertas);
        }

        // GET: Alertas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alertas == null)
            {
                return NotFound();
            }

            var alertas = await _context.Alertas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertas == null)
            {
                return NotFound();
            }

            return View(alertas);
        }

        // POST: Alertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alertas == null)
            {
                return Problem("Entity set 'ProyectoWebContext.Alertas'  is null.");
            }
            var alertas = await _context.Alertas.FindAsync(id);
            if (alertas != null)
            {
                _context.Alertas.Remove(alertas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertasExists(int id)
        {
          return (_context.Alertas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
