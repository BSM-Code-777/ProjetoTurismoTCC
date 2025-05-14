using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using turismoTCC.Data;
using turismoTCC.Models;

namespace turismoTCC.Controllers
{
    [Authorize]
    public class RegistrosController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public RegistrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registros
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var registro = await _context.Registro
                .Where(p => p.IdUsuario == userId)
                .ToListAsync();

            return View(registro);
        }

        // GET: Registros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.Premium)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.idRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registros/Create
        public IActionResult Create()
        {
            ViewData["idPremium"] = new SelectList(_context.Set<Premium>(), "idPremium", "nome");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRegistro,dataInicio,dataFim,IdUsuario,idPremium")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // usando System.Security.Claims
                registro.IdUsuario = userId;

                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idPremium"] = new SelectList(_context.Set<Premium>(), "idPremium", "nome", registro.idPremium);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Id", registro.IdUsuario);
            return View(registro);
        }

        // GET: Registros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["idPremium"] = new SelectList(_context.Set<Premium>(), "idPremium", "nome", registro.idPremium);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Id", registro.IdUsuario);
            return View(registro);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRegistro,dataInicio,dataFim,IdUsuario,idPremium")] Registro registro)
        {
            if (id != registro.idRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.idRegistro))
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
            ViewData["idPremium"] = new SelectList(_context.Set<Premium>(), "idPremium", "nome", registro.idPremium);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "Id", "Id", registro.IdUsuario);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.Premium)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.idRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registro == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Registro'  is null.");
            }
            var registro = await _context.Registro.FindAsync(id);
            if (registro != null)
            {
                _context.Registro.Remove(registro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
          return (_context.Registro?.Any(e => e.idRegistro == id)).GetValueOrDefault();
        }
    }
}
