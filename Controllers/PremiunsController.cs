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
    public class PremiunsController : Controller
    {
        private readonly ApplicationDbContext _context;

       

        public PremiunsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Premiuns
        public async Task<IActionResult> Index()
        {
              return _context.Premium != null ? 
                          View(await _context.Premium.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Premium'  is null.");
        }

        // GET: Premiuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.idPremium == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // GET: Premiuns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Premiuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPremium,nome,periodo,valor")] Premium premium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(premium);
        }

        // GET: Premiuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium.FindAsync(id);
            if (premium == null)
            {
                return NotFound();
            }
            return View(premium);
        }

        // POST: Premiuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPremium,nome,periodo,valor")] Premium premium)
        {
            if (id != premium.idPremium)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremiumExists(premium.idPremium))
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
            return View(premium);
        }

        // GET: Premiuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Premium == null)
            {
                return NotFound();
            }

            var premium = await _context.Premium
                .FirstOrDefaultAsync(m => m.idPremium == id);
            if (premium == null)
            {
                return NotFound();
            }

            return View(premium);
        }

        // POST: Premiuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Premium == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Premium'  is null.");
            }
            var premium = await _context.Premium.FindAsync(id);
            if (premium != null)
            {
                _context.Premium.Remove(premium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremiumExists(int id)
        {
          return (_context.Premium?.Any(e => e.idPremium == id)).GetValueOrDefault();
        }
    }
}
