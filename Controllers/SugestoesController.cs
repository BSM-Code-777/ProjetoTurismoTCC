﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using turismoTCC.Data;
using turismoTCC.Models;

namespace turismoTCC.Controllers
{
    [Authorize]
    public class SugestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SugestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sugestoes
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sugestao = await _context.Sugestao
                .Where(p => p.idUsuario == userId)
                .ToListAsync();

            return View(sugestao);
        }

        // GET: Sugestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sugestao == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.idSugestoes == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // GET: Sugestoes/Create
        public IActionResult Create()
        {
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Sugestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSugestoes,nome,descricao,idUsuario")] Sugestao sugestao)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // usando System.Security.Claims
                sugestao.idUsuario = userId;

                _context.Add(sugestao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", sugestao.nome);
            return View(sugestao);
        }

        // GET: Sugestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sugestao == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao.FindAsync(id);
            if (sugestao == null)
            {
                return NotFound();
            }
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", sugestao.idUsuario);
            return View(sugestao);
        }

        // POST: Sugestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSugestoes,nome,descricao,idUsuario")] Sugestao sugestao)
        {
            if (id != sugestao.idSugestoes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugestao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugestaoExists(sugestao.idSugestoes))
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
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", sugestao.idUsuario);
            return View(sugestao);
        }

        // GET: Sugestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sugestao == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestao
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.idSugestoes == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // POST: Sugestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sugestao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sugestao'  is null.");
            }
            var sugestao = await _context.Sugestao.FindAsync(id);
            if (sugestao != null)
            {
                _context.Sugestao.Remove(sugestao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugestaoExists(int id)
        {
          return (_context.Sugestao?.Any(e => e.idSugestoes == id)).GetValueOrDefault();
        }
    }
}
