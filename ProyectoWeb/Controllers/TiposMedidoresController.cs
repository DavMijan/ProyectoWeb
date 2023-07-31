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
    public class TiposMedidoresController : Controller
    {
        private readonly ProyectoWebContext _context;

        public TiposMedidoresController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: TiposMedidores
        public async Task<IActionResult> Index()
        {
              return _context.TiposMedidores != null ? 
                          View(await _context.TiposMedidores.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.TiposMedidores'  is null.");
        }

        // GET: TiposMedidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposMedidores == null)
            {
                return NotFound();
            }

            var tiposMedidores = await _context.TiposMedidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposMedidores == null)
            {
                return NotFound();
            }

            return View(tiposMedidores);
        }

        // GET: TiposMedidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposMedidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMedidor,EstadoTipoMedidor")] TiposMedidores tiposMedidores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposMedidores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposMedidores);
        }

        // GET: TiposMedidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposMedidores == null)
            {
                return NotFound();
            }

            var tiposMedidores = await _context.TiposMedidores.FindAsync(id);
            if (tiposMedidores == null)
            {
                return NotFound();
            }
            return View(tiposMedidores);
        }

        // POST: TiposMedidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoMedidor,EstadoTipoMedidor")] TiposMedidores tiposMedidores)
        {
            if (id != tiposMedidores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposMedidores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposMedidoresExists(tiposMedidores.Id))
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
            return View(tiposMedidores);
        }

        // GET: TiposMedidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposMedidores == null)
            {
                return NotFound();
            }

            var tiposMedidores = await _context.TiposMedidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposMedidores == null)
            {
                return NotFound();
            }

            return View(tiposMedidores);
        }

        // POST: TiposMedidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposMedidores == null)
            {
                return Problem("Entity set 'ProyectoWebContext.TiposMedidores'  is null.");
            }
            var tiposMedidores = await _context.TiposMedidores.FindAsync(id);
            if (tiposMedidores != null)
            {
                _context.TiposMedidores.Remove(tiposMedidores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposMedidoresExists(int id)
        {
          return (_context.TiposMedidores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
