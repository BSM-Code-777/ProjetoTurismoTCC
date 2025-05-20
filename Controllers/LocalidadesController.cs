using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using turismoTCC.Data;
using turismoTCC.Models;

namespace turismoTCC.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Localidades
        public async Task<IActionResult> Index()
        {
              return _context.Localidade != null ? 
                          View(await _context.Localidade.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Localidade'  is null.");
        }

        // GET: Localidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localidade == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade
                .FirstOrDefaultAsync(m => m.idLocal == id);
            if (localidade == null)
            {
                return NotFound();
            }

            return View(localidade);
        }

        // GET: Localidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idLocal,nome,linkMaps,latitude,longitude,bairro,endereco,rua,descricao,tipo")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localidade);
        }

        // GET: Localidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localidade == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade.FindAsync(id);
            if (localidade == null)
            {
                return NotFound();
            }
            return View(localidade);
        }

        // POST: Localidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idLocal,nome,linkMaps,latitude,longitude,bairro,endereco,rua,descricao,tipo")] Localidade localidade)
        {
            if (id != localidade.idLocal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadeExists(localidade.idLocal))
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
            return View(localidade);
        }

        // GET: Localidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localidade == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade
                .FirstOrDefaultAsync(m => m.idLocal == id);
            if (localidade == null)
            {
                return NotFound();
            }

            return View(localidade);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localidade == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Localidade'  is null.");
            }
            var localidade = await _context.Localidade.FindAsync(id);
            if (localidade != null)
            {
                _context.Localidade.Remove(localidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadeExists(int id)
        {
          return (_context.Localidade?.Any(e => e.idLocal == id)).GetValueOrDefault();
        }
    }
}
