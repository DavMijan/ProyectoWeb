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
    public class DimTiempoesController : Controller
    {
        private readonly ProyectoWebContext _context;

        public DimTiempoesController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: DimTiempoes
        public async Task<IActionResult> Index()
        {
              return _context.DimTiempo != null ? 
                          View(await _context.DimTiempo.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.DimTiempo'  is null.");
        }

        // GET: DimTiempoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DimTiempo == null)
            {
                return NotFound();
            }

            var dimTiempo = await _context.DimTiempo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dimTiempo == null)
            {
                return NotFound();
            }

            return View(dimTiempo);
        }

        // GET: DimTiempoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimTiempoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Anio,Mes,Dia,NombreMes,NombreDia")] DimTiempo dimTiempo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimTiempo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dimTiempo);
        }

        // GET: DimTiempoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DimTiempo == null)
            {
                return NotFound();
            }

            var dimTiempo = await _context.DimTiempo.FindAsync(id);
            if (dimTiempo == null)
            {
                return NotFound();
            }
            return View(dimTiempo);
        }

        // POST: DimTiempoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Anio,Mes,Dia,NombreMes,NombreDia")] DimTiempo dimTiempo)
        {
            if (id != dimTiempo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimTiempo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimTiempoExists(dimTiempo.Id))
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
            return View(dimTiempo);
        }

        // GET: DimTiempoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DimTiempo == null)
            {
                return NotFound();
            }

            var dimTiempo = await _context.DimTiempo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dimTiempo == null)
            {
                return NotFound();
            }

            return View(dimTiempo);
        }

        // POST: DimTiempoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DimTiempo == null)
            {
                return Problem("Entity set 'ProyectoWebContext.DimTiempo'  is null.");
            }
            var dimTiempo = await _context.DimTiempo.FindAsync(id);
            if (dimTiempo != null)
            {
                _context.DimTiempo.Remove(dimTiempo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimTiempoExists(int id)
        {
          return (_context.DimTiempo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
