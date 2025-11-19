using Aplikacja_wspierajaca_rozwoj_dziecka.Data;
using Aplikacja_wspierajaca_rozwoj_dziecka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Controllers
{
    public class DzieckoUmiejetnoscController : Controller
    {
        private readonly AppDbContext _context;

        public DzieckoUmiejetnoscController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DzieckoUmiejetnosc/Create?dzieckoId=5
        public async Task<IActionResult> Create(int dzieckoId)
        {
            var dziecko = await _context.Dzieci.FindAsync(dzieckoId);
            if (dziecko == null)
            {
                return NotFound();
            }

            ViewBag.Dziecko = dziecko;

            // wszystkie umiejętności (na start może być tak)
            var umiejetnosci = await _context.Umiejetnosci.ToListAsync();
            ViewData["UmiejetnoscId"] = new SelectList(umiejetnosci, "Id", "Nazwa");

            var model = new DzieckoUmiejetnosc
            {
                DzieckoId = dzieckoId,
                Status = StatusUmiejetnosci.NieRozpoczeto,
                DataStatusu = DateTime.UtcNow
            };

            return View(model);
        }

        // POST: DzieckoUmiejetnosc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DzieckoUmiejetnosc model)
        {
            if (!ModelState.IsValid)
            {
                var dziecko = await _context.Dzieci.FindAsync(model.DzieckoId);
                ViewBag.Dziecko = dziecko;

                var umiejetnosci = await _context.Umiejetnosci.ToListAsync();
                ViewData["UmiejetnoscId"] = new SelectList(umiejetnosci, "Id", "Nazwa", model.UmiejetnoscId);

                return View(model);
            }

            model.DataStatusu = DateTime.UtcNow;

            _context.DzieckoUmiejetnosci.Add(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Jeżeli dodajesz tę samą umiejętność drugi raz temu samemu dziecku,
                // złamiesz unikalny indeks (DzieckoId + UmiejetnoscId).
                ModelState.AddModelError(string.Empty, "Ta umiejętność jest już przypisana do tego dziecka.");

                var dziecko = await _context.Dzieci.FindAsync(model.DzieckoId);
                ViewBag.Dziecko = dziecko;

                var umiejetnosci = await _context.Umiejetnosci.ToListAsync();
                ViewData["UmiejetnoscId"] = new SelectList(umiejetnosci, "Id", "Nazwa", model.UmiejetnoscId);

                return View(model);
            }

            return RedirectToAction("Details", "Dziecko", new { id = model.DzieckoId });
        }
    }
}
