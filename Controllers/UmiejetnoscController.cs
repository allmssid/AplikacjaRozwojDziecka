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
    public class UmiejetnoscController : Controller
    {
        private readonly AppDbContext _context;

        public UmiejetnoscController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Umiejetnosc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Umiejetnosci.ToListAsync());
        }

        // GET: Umiejetnosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umiejetnosc = await _context.Umiejetnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (umiejetnosc == null)
            {
                return NotFound();
            }

            return View(umiejetnosc);
        }

        // GET: Umiejetnosc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Umiejetnosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Kierunek,ZalecanyWiekOdRoku,ZalecanyWiekDoRoku,CzyWlasna")] Umiejetnosc umiejetnosc)


        {
            if (ModelState.IsValid)
            {
                _context.Add(umiejetnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(umiejetnosc);
        }

        // GET: Umiejetnosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umiejetnosc = await _context.Umiejetnosci.FindAsync(id);
            if (umiejetnosc == null)
            {
                return NotFound();
            }
            return View(umiejetnosc);
        }

        // POST: Umiejetnosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Kierunek,ZalecanyWiekOdRoku,ZalecanyWiekDoRoku,CzyWlasna")] Umiejetnosc umiejetnosc)


        {
            if (id != umiejetnosc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(umiejetnosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UmiejetnoscExists(umiejetnosc.Id))
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
            return View(umiejetnosc);
        }

        // GET: Umiejetnosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var umiejetnosc = await _context.Umiejetnosci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (umiejetnosc == null)
            {
                return NotFound();
            }

            return View(umiejetnosc);
        }

        // POST: Umiejetnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var umiejetnosc = await _context.Umiejetnosci.FindAsync(id);
            if (umiejetnosc != null)
            {
                _context.Umiejetnosci.Remove(umiejetnosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UmiejetnoscExists(int id)
        {
            return _context.Umiejetnosci.Any(e => e.Id == id);
        }
    }
}
