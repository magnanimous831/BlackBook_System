using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;

namespace BlackBook_System.Controllers
{
    public class StudentsEnrollmentsController : Controller
    {
        private readonly BlackBook_SystemContext _context;

        public StudentsEnrollmentsController(BlackBook_SystemContext context)
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
            {
                return NotFound();
            }

            var studentsEnrollment = await _context.StudentsEnrollment
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (studentsEnrollment == null)
            {
                return NotFound();
            }

            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Create
        public IActionResult Create()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_Create"); // Return only the partial view if it's an AJAX request
            }
            return View(); // Default rendering for a full page load
        }


        // POST: StudentsEnrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentsEnrollment studentsEnrollment, IFormFile CertificateFile)
        {
            if (ModelState.IsValid)
            {
                // Automatically set Address from SubCounty and County
                studentsEnrollment.ADDRESS = $"{studentsEnrollment.SubCounty}, {studentsEnrollment.County}";

                if (CertificateFile != null && CertificateFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Get original file extension
                    string fileExtension = Path.GetExtension(CertificateFile.FileName);
                    
                    // Generate a unique file name using the original file name
                    var originalFileName = Path.GetFileNameWithoutExtension(CertificateFile.FileName);
                    var uniqueFileName = $"{originalFileName}_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";

                    // Construct the full file path
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await CertificateFile.CopyToAsync(fileStream);
                    }

                    // Store only the file name in the database
                    studentsEnrollment.CertificateName = uniqueFileName;
                }

                _context.Add(studentsEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsEnrollment = await _context.StudentsEnrollment.FindAsync(id);
            if (studentsEnrollment == null)
            {
                return NotFound();
            }
            return View(studentsEnrollment);
        }

        // POST: StudentsEnrollments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentsEnrollment studentsEnrollment, IFormFile CertificateFile)
        {
            if (id != studentsEnrollment.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Automatically update Address during Edit
                    studentsEnrollment.ADDRESS = $"{studentsEnrollment.SubCounty}, {studentsEnrollment.County}";

                    if (CertificateFile != null && CertificateFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "certificates");

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Delete old file if exists
                        if (!string.IsNullOrEmpty(studentsEnrollment.CertificateName))
                        {
                            var oldFilePath = Path.Combine(uploadsFolder, studentsEnrollment.CertificateName);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Get original file extension
                        string fileExtension = Path.GetExtension(CertificateFile.FileName);
                        
                        // Generate a unique file name using the original file name
                        var originalFileName = Path.GetFileNameWithoutExtension(CertificateFile.FileName);
                        var uniqueFileName = $"{originalFileName}_{Guid.NewGuid().ToString().Substring(0, 8)}{fileExtension}";

                        // Construct the full file path
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await CertificateFile.CopyToAsync(fileStream);
                        }

                        // Store only the file name in the database
                        studentsEnrollment.CertificateName = uniqueFileName;
                    }
                    
                    _context.Update(studentsEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsEnrollmentExists(studentsEnrollment.EnrollmentID))
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
            return View(studentsEnrollment);
        }

        // GET: StudentsEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsEnrollment = await _context.StudentsEnrollment
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (studentsEnrollment == null)
            {
                return NotFound();
            }

            return View(studentsEnrollment);
        }

        // POST: StudentsEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsEnrollment = await _context.StudentsEnrollment.FindAsync(id);
            if (studentsEnrollment != null)
            {
                _context.StudentsEnrollment.Remove(studentsEnrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsEnrollmentExists(int id)
        {
            return _context.StudentsEnrollment.Any(e => e.EnrollmentID == id);
        }
    }
}
