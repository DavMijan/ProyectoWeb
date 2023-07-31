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
    public class EncabezadosController : Controller
    {
        private readonly ProyectoWebContext _context;

        public EncabezadosController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: Encabezados
        public async Task<IActionResult> Index()
        {
              return _context.Encabezados != null ? 
                          View(await _context.Encabezados.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.Encabezados'  is null.");
        }

        // GET: Encabezados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Encabezados == null)
            {
                return NotFound();
            }

            var encabezados = await _context.Encabezados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezados == null)
            {
                return NotFound();
            }

            return View(encabezados);
        }

        // GET: Encabezados/Create
        public IActionResult Create()
        {
            ViewData["FechaID"] = new SelectList(_context.DimTiempo, "Id", "Id");
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Nis");
            return View();
        }

        // POST: Encabezados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaEncabezado,IdMedidor,FechaID,EstadoEncabezado")] Encabezados encabezados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encabezados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encabezados);
        }

        // GET: Encabezados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["FechaID"] = new SelectList(_context.DimTiempo, "Id", "Fecha");
            ViewData["IdMedidor"] = new SelectList(_context.Medidores, "Id", "Nis");
            if (id == null || _context.Encabezados == null)
            {
                return NotFound();
            }

            var encabezados = await _context.Encabezados.FindAsync(id);
            if (encabezados == null)
            {
                return NotFound();
            }
            return View(encabezados);
        }

        // POST: Encabezados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaEncabezado,IdMedidor,FechaID,EstadoEncabezado")] Encabezados encabezados)
        {
            if (id != encabezados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encabezados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncabezadosExists(encabezados.Id))
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
            return View(encabezados);
        }

        // GET: Encabezados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Encabezados == null)
            {
                return NotFound();
            }

            var encabezados = await _context.Encabezados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encabezados == null)
            {
                return NotFound();
            }

            return View(encabezados);
        }

        // POST: Encabezados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Encabezados == null)
            {
                return Problem("Entity set 'ProyectoWebContext.Encabezados'  is null.");
            }
            var encabezados = await _context.Encabezados.FindAsync(id);
            if (encabezados != null)
            {
                _context.Encabezados.Remove(encabezados);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncabezadosExists(int id)
        {
          return (_context.Encabezados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
