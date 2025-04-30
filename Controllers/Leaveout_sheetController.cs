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
    public class Leaveout_sheetController : Controller
    {
        private readonly BlackBook_SystemContext _context;

        public Leaveout_sheetController(BlackBook_SystemContext context)
        {
            _context = context;
        }

        // GET: Leaveout_sheet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leaveout_sheet.ToListAsync());
        }

        // GET: Leaveout_sheet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveout_sheet = await _context.Leaveout_sheet
                .FirstOrDefaultAsync(m => m.LEAVEOUTID == id);
            if (leaveout_sheet == null)
            {
                return NotFound();
            }

            return View(leaveout_sheet);
        }

        // GET: Leaveout_sheet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leaveout_sheet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LEAVEOUTID,STUDENTNAME,ADMNO,CLASS,LEAVINGDATE,REASONFORLEAVING,RETURNDATE,CLASSTEACHER,SIGNATUREDATE,TOD,TODDATE,PRINCIPAL,SIGNDATE")] Leaveout_sheet leaveout_sheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveout_sheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveout_sheet);
        }

        // GET: Leaveout_sheet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveout_sheet = await _context.Leaveout_sheet.FindAsync(id);
            if (leaveout_sheet == null)
            {
                return NotFound();
            }
            return View(leaveout_sheet);
        }

        // POST: Leaveout_sheet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LEAVEOUTID,STUDENTNAME,ADMNO,CLASS,LEAVINGDATE,REASONFORLEAVING,RETURNDATE,CLASSTEACHER,SIGNATUREDATE,TOD,TODDATE,PRINCIPAL,SIGNDATE")] Leaveout_sheet leaveout_sheet)
        {
            if (id != leaveout_sheet.LEAVEOUTID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveout_sheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Leaveout_sheetExists(leaveout_sheet.LEAVEOUTID))
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
            return View(leaveout_sheet);
        }

        // GET: Leaveout_sheet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveout_sheet = await _context.Leaveout_sheet
                .FirstOrDefaultAsync(m => m.LEAVEOUTID == id);
            if (leaveout_sheet == null)
            {
                return NotFound();
            }

            return View(leaveout_sheet);
        }

        // POST: Leaveout_sheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveout_sheet = await _context.Leaveout_sheet.FindAsync(id);
            if (leaveout_sheet != null)
            {
                _context.Leaveout_sheet.Remove(leaveout_sheet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Leaveout_sheetExists(int id)
        {
            return _context.Leaveout_sheet.Any(e => e.LEAVEOUTID == id);
        }

        // GET: Leaveout_sheet/SearchStudent
        [HttpGet]
        public async Task<IActionResult> SearchStudent(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query is empty.");
            }

            var student = await _context.StudentsEnrollment
                .Where(s => s.ADMNO == query || s.STUDENTNAME.Contains(query))
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Json(new
            {
                STUDENTNAME = student.STUDENTNAME,
                ADMNO = student.ADMNO,
                CLASS = student.CLASSADMITTED
            });
        }
    }
}