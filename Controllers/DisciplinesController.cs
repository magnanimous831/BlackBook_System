using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;

namespace BlackBook_System.Controllers
{
    public class DisciplinesController : Controller
    {
        private readonly BlackBook_SystemContext _context;

        public DisciplinesController(BlackBook_SystemContext context)
        {
            _context = context;
        }

        // GET: Disciplines
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Discipline == null)
            {
                return Problem("Entity set 'BlackBook_System.Context'  is null.");
            }

            var discipline = from m in _context.Discipline
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                discipline = discipline.Where(s => s.STUDENTNAME!.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await discipline.ToListAsync());
        }

        // GET: Disciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //lambda expression method to select discipline entities that match the route data or query string value.
            var discipline = await _context.Discipline
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Disciplines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DATE,ADMNO,STUDENTNAME,CLASS,INDISCIPLINECASE,AUDITED_BY,AUDITED_DATETIME,ACTION_TAKEN,CASE_STATUS")] Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        // GET: Disciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return View(discipline);
        }

        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DATE,ADMNO,STUDENTNAME,CLASS,INDISCIPLINECASE,AUDITED_BY,AUDITED_DATETIME,ACTION_TAKEN,CASE_STATUS")] Discipline discipline)
        {
            if (id != discipline.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineExists(discipline.ID))
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
            return View(discipline);
        }

        // GET: Disciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Discipline
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discipline = await _context.Discipline.FindAsync(id);
            if (discipline != null)
            {
                _context.Discipline.Remove(discipline);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> FixNullDates()
        {
            // Update DATE column where it is NULL
            await _context.Database.ExecuteSqlRawAsync(
                "UPDATE Discipline SET DATE = GETDATE() WHERE DATE IS NULL");

            // Update AUDITED_DATETIME column where it is NULL
            await _context.Database.ExecuteSqlRawAsync(
                "UPDATE Discipline SET AUDITED_DATETIME = GETDATE() WHERE AUDITED_DATETIME IS NULL");

            return Content("NULL DATE and AUDITED_DATETIME fields updated successfully.");
        }

        private bool DisciplineExists(int id)
        {
            return _context.Discipline.Any(e => e.ID == id);
        }
    }
}
