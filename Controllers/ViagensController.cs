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
    public class ViagensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Viagens
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viagem = await _context.Viagem
                .Where(p => p.idUsuario == userId)
                .ToListAsync();

            return View(viagem);
        }

        // GET: Viagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Localidade)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.IdViagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagens/Create
        public IActionResult Create()
        {
            ViewData["idLocal"] = new SelectList(_context.Set<Localidade>(), "idLocal", "nome");
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Viagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdViagem,nome,idLocal,idUsuario")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // usando System.Security.Claims
                viagem.idUsuario = userId;

                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idLocal"] = new SelectList(_context.Set<Localidade>(), "idLocal", "descricao", viagem.idLocal);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", viagem.idUsuario);
            return View(viagem);
        }

        // GET: Viagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            ViewData["idLocal"] = new SelectList(_context.Set<Localidade>(), "idLocal", "descricao", viagem.idLocal);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", viagem.idUsuario);
            return View(viagem);
        }

        // POST: Viagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdViagem,nome,idLocal,idUsuario")] Viagem viagem)
        {
            if (id != viagem.IdViagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.IdViagem))
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
            ViewData["idLocal"] = new SelectList(_context.Set<Localidade>(), "idLocal", "nome", viagem.idLocal);
            ViewData["idUsuario"] = new SelectList(_context.Usuario, "Id", "Id", viagem.idUsuario);
            return View(viagem);
        }

        // GET: Viagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viagem == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .Include(v => v.Localidade)
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.IdViagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viagem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Viagem'  is null.");
            }
            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem != null)
            {
                _context.Viagem.Remove(viagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
          return (_context.Viagem?.Any(e => e.IdViagem == id)).GetValueOrDefault();
        }
    }
}
