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
    public class Teachers_ListController : Controller
    {
        private readonly BlackBookDbContext _context;

        public Teachers_ListController(BlackBookDbContext context)
        {
            _context = context;
        }

        // GET: Teachers_List
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers_List.ToListAsync());
        }

        // GET: Teachers_List/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers_List = await _context.Teachers_List
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers_List == null)
            {
                return NotFound();
            }

            return View(teachers_List);
        }

        // GET: Teachers_List/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers_List/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Gender,Class,Email,Username,Subjects,Phonenumber")] Teachers_List teachers_List)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachers_List);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Teacher created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(teachers_List);
        }

        // GET: Teachers_List/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers_List = await _context.Teachers_List.FindAsync(id);
            if (teachers_List == null)
            {
                return NotFound();
            }
            return View(teachers_List);
        }

        // POST: Teachers_List/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Gender,Class,Email,Username,Subjects,Phonenumber")] Teachers_List teachers_List)
        {
            if (id != teachers_List.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers_List);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Teacher updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Teachers_ListExists(teachers_List.Id))
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
            return View(teachers_List);
        }

        // GET: Teachers_List/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers_List = await _context.Teachers_List
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachers_List == null)
            {
                return NotFound();
            }

            return View(teachers_List);
        }

        // POST: Teachers_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers_List = await _context.Teachers_List.FindAsync(id);
            if (teachers_List != null)
            {
                _context.Teachers_List.Remove(teachers_List);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Teacher deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool Teachers_ListExists(int id)
        {
            return _context.Teachers_List.Any(e => e.Id == id);
        }
    }
}
