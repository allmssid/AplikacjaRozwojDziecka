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
    public class AktywnoscController : Controller
    {
        private readonly AppDbContext _context;

        public AktywnoscController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Aktywnosc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aktywnosci.ToListAsync());
        }

        // GET: Aktywnosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktywnosc = await _context.Aktywnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktywnosc == null)
            {
                return NotFound();
            }

            return View(aktywnosc);
        }

        // GET: Aktywnosc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aktywnosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Opis,Kierunek,ZalecanyWiekOdRoku,ZalecanyWiekDoRoku,SzacowanyCzasMinuty")] Aktywnosc aktywnosc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktywnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aktywnosc);
        }

        // GET: Aktywnosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktywnosc = await _context.Aktywnosci.FindAsync(id);
            if (aktywnosc == null)
            {
                return NotFound();
            }
            return View(aktywnosc);
        }

        // POST: Aktywnosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Opis,Kierunek,ZalecanyWiekOdRoku,ZalecanyWiekDoRoku,SzacowanyCzasMinuty")] Aktywnosc aktywnosc)
        {
            if (id != aktywnosc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktywnosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktywnoscExists(aktywnosc.Id))
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
            return View(aktywnosc);
        }

        // GET: Aktywnosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktywnosc = await _context.Aktywnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aktywnosc == null)
            {
                return NotFound();
            }

            return View(aktywnosc);
        }

        // POST: Aktywnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aktywnosc = await _context.Aktywnosci.FindAsync(id);
            if (aktywnosc != null)
            {
                _context.Aktywnosci.Remove(aktywnosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktywnoscExists(int id)
        {
            return _context.Aktywnosci.Any(e => e.Id == id);
        }
    }
}
