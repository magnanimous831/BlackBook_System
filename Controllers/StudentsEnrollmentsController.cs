<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;
using System.Diagnostics.Metrics;

namespace BlackBook_System.Controllers
{
    public class StudentsEnrollmentsController : Controller
    {
<<<<<<< HEAD
        private readonly BlackBook_SystemContext _context;

        public StudentsEnrollmentsController(BlackBook_SystemContext context)
=======
        private readonly BlackBookDbContext _context;

        public StudentsEnrollmentsController(BlackBookDbContext context)
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
        {
            _context = context;
        }

        // GET: StudentsEnrollments
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentsEnrollment.ToListAsync());
        }

        // GET: StudentsEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsEnrollment = await _context.StudentsEnrollment
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (studentsEnrollment == null)
                return NotFound();

            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Create
        public IActionResult Create()
        {
            ViewBag.Counties = _context.Location
                .Select(l => l.County)
                .Distinct()
                .ToList();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_Create"); // For AJAX

            return View();
        }

        // POST: StudentsEnrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentsEnrollment studentsEnrollment, IFormFile CertificateFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (CertificateFile != null && CertificateFile.Length > 0)
                    {
<<<<<<< HEAD
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "certificates");
=======
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6

                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        string fileExtension = Path.GetExtension(CertificateFile.FileName);
                        var originalFileName = Path.GetFileNameWithoutExtension(CertificateFile.FileName);
                        var uniqueFileName = $"{originalFileName}_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await CertificateFile.CopyToAsync(fileStream);
                        }

                        studentsEnrollment.CertificateName = uniqueFileName;
                    }

                    _context.Add(studentsEnrollment);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Student enrolled successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the student.");
                    System.Diagnostics.Debug.WriteLine($"Error creating student: {ex.Message}");
                }
            }

            // Refill counties if form has errors
            ViewBag.Counties = _context.Location
                .Select(l => l.County)
                .Distinct()
                .ToList();

            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsEnrollment = await _context.StudentsEnrollment.FindAsync(id);
            if (studentsEnrollment == null)
                return NotFound();

            ViewBag.Counties = _context.Location
                .Select(l => l.County)
                .Distinct()
                .ToList();

            return View(studentsEnrollment);
        }

        // POST: StudentsEnrollments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentsEnrollment studentsEnrollment, IFormFile CertificateFile)
        {
            if (id != studentsEnrollment.EnrollmentID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (CertificateFile != null && CertificateFile.Length > 0)
                    {
<<<<<<< HEAD
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "certificates");
=======
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6

                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        // Delete old file
                        if (!string.IsNullOrEmpty(studentsEnrollment.CertificateName))
                        {
                            var oldFilePath = Path.Combine(uploadsFolder, studentsEnrollment.CertificateName);
                            if (System.IO.File.Exists(oldFilePath))
                                System.IO.File.Delete(oldFilePath);
                        }

                        string fileExtension = Path.GetExtension(CertificateFile.FileName);
                        var originalFileName = Path.GetFileNameWithoutExtension(CertificateFile.FileName);
                        var uniqueFileName = $"{originalFileName}_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await CertificateFile.CopyToAsync(fileStream);
                        }

                        studentsEnrollment.CertificateName = uniqueFileName;
                    }

                    _context.Update(studentsEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsEnrollmentExists(studentsEnrollment.EnrollmentID))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Counties = _context.Location
                .Select(l => l.County)
                .Distinct()
                .ToList();

            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var studentsEnrollment = await _context.StudentsEnrollment
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (studentsEnrollment == null)
                return NotFound();

            return View(studentsEnrollment);
        }

        // POST: StudentsEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsEnrollment = await _context.StudentsEnrollment.FindAsync(id);
            if (studentsEnrollment != null)
                _context.StudentsEnrollment.Remove(studentsEnrollment);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsEnrollmentExists(int id)
        {
            return _context.StudentsEnrollment.Any(e => e.EnrollmentID == id);
        }

        // ========= AJAX ENDPOINTS FOR DEPENDENT DROPDOWNS =========

        [HttpGet]
        public JsonResult GetSubCounties(string county)
        {
            var subCounties = _context.Location
                .Where(l => l.County == county)
                .Select(l => l.SubCounty)
                .Distinct()
                .ToList();

            return Json(subCounties);
        }

        [HttpGet]
        public JsonResult GetWards(string county, string subCounty)
        {
            var wards = _context.Location
                .Where(l => l.County == county && l.SubCounty == subCounty)
                .Select(l => l.Ward)
                .Distinct()
                .ToList();

            return Json(wards);
        }
    }
<<<<<<< HEAD
} 
=======
}
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
