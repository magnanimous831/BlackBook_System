using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;

namespace BlackBook_System.Controllers
{
    public class OccurrencesController : Controller
    {
        private readonly BlackBookDbContext _context;

        public OccurrencesController(BlackBookDbContext context)
        {
            _context = context;
        }

        // GET: Occurrences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Occurrences.ToListAsync());
        }

        // GET: Occurrences/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var occurrences = await _context.Occurrences
                .FirstOrDefaultAsync(m => m.id == id);
            if (occurrences == null)
            {
                return NotFound();
            }

            return View(occurrences);
        }

        // GET: Occurrences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occurrences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (int id, [Bind("DAY,TeacherOnDuty,DAILYACTIVITY,PLACE,RECORDED_BY,REMARKS")] Occurrences occurrences)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occurrences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(occurrences);
        }

        // GET: Occurrences/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var occurrences = await _context.Occurrences.FindAsync(id);
            if (occurrences == null)
            {
                return NotFound();
            }
            return View(occurrences);
        }

        // POST: Occurrences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DAY,TeacherOnDuty,DAILYACTIVITY,PLACE,RECORDED_BY,REMARKS")] Occurrences occurrences)
        {
            if (id != occurrences.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occurrences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccurrencesExists(occurrences.id))
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
            return View(occurrences);
        }

        // GET: Occurrences/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var occurrences = await _context.Occurrences
                .FirstOrDefaultAsync(m => m.id == id);
            if (occurrences == null)
            {
                return NotFound();
            }

            return View(occurrences);
        }

        // POST: Occurrences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occurrences = await _context.Occurrences.FindAsync(id);
            if (occurrences != null)
            {
                _context.Occurrences.Remove(occurrences);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccurrencesExists(int id)
        {
            return _context.Occurrences.Any(e => e.id == id);
        }
    }
}
