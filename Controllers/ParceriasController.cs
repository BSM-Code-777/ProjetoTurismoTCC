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
    public class ParceriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParceriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parcerias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parceria.Include(p => p.Localidade).Include(p => p.Premium);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parcerias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parceria == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parceria
                .Include(p => p.Localidade)
                .Include(p => p.Premium)
                .FirstOrDefaultAsync(m => m.idParceria == id);
            if (parceria == null)
            {
                return NotFound();
            }

            return View(parceria);
        }

        // GET: Parcerias/Create
        public IActionResult Create()
        {
            ViewData["idLocal"] = new SelectList(_context.Localidade, "idLocal", "bairro");
            ViewData["idPremium"] = new SelectList(_context.Premium, "idPremium", "nome");
            return View();
        }

        // POST: Parcerias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idParceria,beneficio,idLocal,idPremium")] Parceria parceria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parceria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idLocal"] = new SelectList(_context.Localidade, "idLocal", "bairro", parceria.idLocal);
            ViewData["idPremium"] = new SelectList(_context.Premium, "idPremium", "nome", parceria.idPremium);
            return View(parceria);
        }

        // GET: Parcerias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parceria == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parceria.FindAsync(id);
            if (parceria == null)
            {
                return NotFound();
            }
            ViewData["idLocal"] = new SelectList(_context.Localidade, "idLocal", "bairro", parceria.idLocal);
            ViewData["idPremium"] = new SelectList(_context.Premium, "idPremium", "nome", parceria.idPremium);
            return View(parceria);
        }

        // POST: Parcerias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idParceria,beneficio,idLocal,idPremium")] Parceria parceria)
        {
            if (id != parceria.idParceria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parceria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParceriaExists(parceria.idParceria))
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
            ViewData["idLocal"] = new SelectList(_context.Localidade, "idLocal", "bairro", parceria.idLocal);
            ViewData["idPremium"] = new SelectList(_context.Premium, "idPremium", "nome", parceria.idPremium);
            return View(parceria);
        }

        // GET: Parcerias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parceria == null)
            {
                return NotFound();
            }

            var parceria = await _context.Parceria
                .Include(p => p.Localidade)
                .Include(p => p.Premium)
                .FirstOrDefaultAsync(m => m.idParceria == id);
            if (parceria == null)
            {
                return NotFound();
            }

            return View(parceria);
        }

        // POST: Parcerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parceria == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Parceria'  is null.");
            }
            var parceria = await _context.Parceria.FindAsync(id);
            if (parceria != null)
            {
                _context.Parceria.Remove(parceria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParceriaExists(int id)
        {
          return (_context.Parceria?.Any(e => e.idParceria == id)).GetValueOrDefault();
        }
    }
}
