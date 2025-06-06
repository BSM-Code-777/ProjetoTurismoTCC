﻿using System;
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
    public class BeneficiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Beneficios
        public async Task<IActionResult> Index()
        {
              return _context.Beneficio != null ? 
                          View(await _context.Beneficio.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Beneficio'  is null.");
        }

        // GET: Beneficios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Beneficio == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficio
                .FirstOrDefaultAsync(m => m.idBeneficio == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // GET: Beneficios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idBeneficio,desconto,tipo")] Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficio);
        }

        // GET: Beneficios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Beneficio == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficio.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }

        // POST: Beneficios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idBeneficio,desconto,tipo")] Beneficio beneficio)
        {
            if (id != beneficio.idBeneficio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficioExists(beneficio.idBeneficio))
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
            return View(beneficio);
        }

        // GET: Beneficios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Beneficio == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficio
                .FirstOrDefaultAsync(m => m.idBeneficio == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // POST: Beneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Beneficio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Beneficio'  is null.");
            }
            var beneficio = await _context.Beneficio.FindAsync(id);
            if (beneficio != null)
            {
                _context.Beneficio.Remove(beneficio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficioExists(int id)
        {
          return (_context.Beneficio?.Any(e => e.idBeneficio == id)).GetValueOrDefault();
        }
    }
}
