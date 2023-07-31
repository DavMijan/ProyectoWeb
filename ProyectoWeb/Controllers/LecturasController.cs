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
    public class LecturasController : Controller
    {
        private readonly ProyectoWebContext _context;

        public LecturasController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: Lecturas
        public async Task<IActionResult> Index()
        {
              return _context.Lecturas != null ? 
                          View(await _context.Lecturas.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.Lecturas'  is null.");
        }

        // GET: Lecturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lecturas == null)
            {
                return NotFound();
            }

            var lecturas = await _context.Lecturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturas == null)
            {
                return NotFound();
            }

            return View(lecturas);
        }

        // GET: Lecturas/Create
        public IActionResult Create()
        {
            ViewData["FechaID"] = new SelectList(_context.DimTiempo, "Id", "Fecha");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado");
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Nis");
            return View();
        }

        // POST: Lecturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMedidor,FechaID,IdEmpleado,Lectura,EstadoLectura")] Lecturas lecturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturas);
        }

        // GET: Lecturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["FechaID"] = new SelectList(_context.DimTiempo, "Id", "Fecha");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado");
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Nis");
            if (id == null || _context.Lecturas == null)
            {
                return NotFound();
            }

            var lecturas = await _context.Lecturas.FindAsync(id);
            if (lecturas == null)
            {
                return NotFound();
            }
            return View(lecturas);
        }

        // POST: Lecturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMedidor,FechaID,IdEmpleado,Lectura,EstadoLectura")] Lecturas lecturas)
        {
            if (id != lecturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturasExists(lecturas.Id))
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
            return View(lecturas);
        }

        // GET: Lecturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lecturas == null)
            {
                return NotFound();
            }

            var lecturas = await _context.Lecturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturas == null)
            {
                return NotFound();
            }

            return View(lecturas);
        }

        // POST: Lecturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lecturas == null)
            {
                return Problem("Entity set 'ProyectoWebContext.Lecturas'  is null.");
            }
            var lecturas = await _context.Lecturas.FindAsync(id);
            if (lecturas != null)
            {
                _context.Lecturas.Remove(lecturas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturasExists(int id)
        {
          return (_context.Lecturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
