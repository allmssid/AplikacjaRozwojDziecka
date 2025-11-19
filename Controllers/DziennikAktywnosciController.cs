using Aplikacja_wspierajaca_rozwoj_dziecka.Data;
using Aplikacja_wspierajaca_rozwoj_dziecka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Controllers
{
    public class DziennikAktywnosciController : Controller
    {
        private readonly AppDbContext _context;

        public DziennikAktywnosciController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DziennikAktywnosci/Create?dzieckoId=5
        public async Task<IActionResult> Create(int dzieckoId)
        {
            var dziecko = await _context.Dzieci.FindAsync(dzieckoId);
            if (dziecko == null)
                return NotFound();

            ViewBag.Dziecko = dziecko;

            var aktywnosci = await _context.Aktywnosci.ToListAsync();
            ViewData["AktywnoscId"] = new SelectList(aktywnosci, "Id", "Tytul");

            var model = new DziennikAktywnosci
            {
                DzieckoId = dzieckoId,
                Data = DateTime.Today
            };

            return View(model);
        }

        // POST: DziennikAktywnosci/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DziennikAktywnosci model)
        {
            if (!ModelState.IsValid)
            {
                var dziecko = await _context.Dzieci.FindAsync(model.DzieckoId);
                ViewBag.Dziecko = dziecko;

                var aktywnosci = await _context.Aktywnosci.ToListAsync();
                ViewData["AktywnoscId"] = new SelectList(aktywnosci, "Id", "Tytul", model.AktywnoscId);

                return View(model);
            }

            _context.DziennikiAktywnosci.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Dziecko", new { id = model.DzieckoId });
        }
    }
}
