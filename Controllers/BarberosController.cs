using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberiaMVC_Core.Models;

namespace BarberiaMVC_Core.Controllers
{
    public class BarberosController : Controller
    {
        private readonly BarberiaContext _context;

        public BarberosController(BarberiaContext context)
        {
            _context = context;
        }

        // GET: Barberos
        public async Task<IActionResult> Index()
        {
            var barberiaContext = _context.Barberos.Include(b => b.Usuario);
            return View(await barberiaContext.ToListAsync());
        }

        // GET: Barberos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbero = await _context.Barberos
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barbero == null)
            {
                return NotFound();
            }

            return View(barbero);
        }

        // GET: Barberos/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Apellido");
            return View();
        }

        // POST: Barberos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,Especialidad")] Barbero barbero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barbero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Apellido", barbero.IdUsuario);
            return View(barbero);
        }

        // GET: Barberos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbero = await _context.Barberos.FindAsync(id);
            if (barbero == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Apellido", barbero.IdUsuario);
            return View(barbero);
        }

        // POST: Barberos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,Especialidad")] Barbero barbero)
        {
            if (id != barbero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barbero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberoExists(barbero.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Apellido", barbero.IdUsuario);
            return View(barbero);
        }

        // GET: Barberos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barbero = await _context.Barberos
                .Include(b => b.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barbero == null)
            {
                return NotFound();
            }

            return View(barbero);
        }

        // POST: Barberos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barbero = await _context.Barberos.FindAsync(id);
            if (barbero != null)
            {
                _context.Barberos.Remove(barbero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberoExists(int id)
        {
            return _context.Barberos.Any(e => e.Id == id);
        }
    }
}
