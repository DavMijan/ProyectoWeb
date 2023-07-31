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
    public class TiposUsuariosController : Controller
    {
        private readonly ProyectoWebContext _context;

        public TiposUsuariosController(ProyectoWebContext context)
        {
            _context = context;
        }

        // GET: TiposUsuarios
        public async Task<IActionResult> Index()
        {
              return _context.TiposUsuarios != null ? 
                          View(await _context.TiposUsuarios.ToListAsync()) :
                          Problem("Entity set 'ProyectoWebContext.TiposUsuarios'  is null.");
        }

        // GET: TiposUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposUsuarios == null)
            {
                return NotFound();
            }

            var tiposUsuarios = await _context.TiposUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposUsuarios == null)
            {
                return NotFound();
            }

            return View(tiposUsuarios);
        }

        // GET: TiposUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoUsuario,EstadoUsuario")] TiposUsuarios tiposUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposUsuarios);
        }

        // GET: TiposUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposUsuarios == null)
            {
                return NotFound();
            }

            var tiposUsuarios = await _context.TiposUsuarios.FindAsync(id);
            if (tiposUsuarios == null)
            {
                return NotFound();
            }
            return View(tiposUsuarios);
        }

        // POST: TiposUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoUsuario,EstadoUsuario")] TiposUsuarios tiposUsuarios)
        {
            if (id != tiposUsuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposUsuariosExists(tiposUsuarios.Id))
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
            return View(tiposUsuarios);
        }

        // GET: TiposUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposUsuarios == null)
            {
                return NotFound();
            }

            var tiposUsuarios = await _context.TiposUsuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposUsuarios == null)
            {
                return NotFound();
            }

            return View(tiposUsuarios);
        }

        // POST: TiposUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposUsuarios == null)
            {
                return Problem("Entity set 'ProyectoWebContext.TiposUsuarios'  is null.");
            }
            var tiposUsuarios = await _context.TiposUsuarios.FindAsync(id);
            if (tiposUsuarios != null)
            {
                _context.TiposUsuarios.Remove(tiposUsuarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposUsuariosExists(int id)
        {
          return (_context.TiposUsuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
