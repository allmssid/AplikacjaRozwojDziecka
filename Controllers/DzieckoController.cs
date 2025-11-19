using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplikacja_wspierajaca_rozwoj_dziecka.Data;
using Aplikacja_wspierajaca_rozwoj_dziecka.Models;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Controllers
{
    public class DzieckoController : Controller
    {
        private readonly AppDbContext _context;

        public DzieckoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dziecko
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dzieci.ToListAsync());
        }

        // GET: Dziecko/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dzieci
     .Include(d => d.UmiejetnosciDziecka)
         .ThenInclude(du => du.Umiejetnosc)
     .Include(d => d.DziennikiAktywnosci)
         .ThenInclude(da => da.Aktywnosc)
     .FirstOrDefaultAsync(m => m.Id == id);

            if (dziecko == null)
            {
                return NotFound();
            }

            return View(dziecko);
        }




        // GET: Dziecko/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dziecko/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,DataUrodzenia,Notatki")] Dziecko dziecko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dziecko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dziecko);
        }

        // GET: Dziecko/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dzieci.FindAsync(id);
            if (dziecko == null)
            {
                return NotFound();
            }
            return View(dziecko);
        }

        // POST: Dziecko/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,DataUrodzenia,Notatki")] Dziecko dziecko)
        {
            if (id != dziecko.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dziecko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DzieckoExists(dziecko.Id))
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
            return View(dziecko);
        }

        // GET: Dziecko/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziecko = await _context.Dzieci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dziecko == null)
            {
                return NotFound();
            }

            return View(dziecko);
        }

        // POST: Dziecko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dziecko = await _context.Dzieci.FindAsync(id);
            if (dziecko != null)
            {
                _context.Dzieci.Remove(dziecko);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DzieckoExists(int id)
        {
            return _context.Dzieci.Any(e => e.Id == id);
        }
    }
}
