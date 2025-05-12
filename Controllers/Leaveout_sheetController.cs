using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace BlackBook_System.Controllers
{
    public class Leaveout_sheetController :   Controller
    {
        private readonly BlackBookDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Leaveout_sheetController(BlackBookDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        // GET: Leaveout_sheet/Create
        
        public IActionResult Create()
        {
            var now = DateTime.Now;

            var model = new Leaveout_sheet
            {
                STUDENTNAME = "",
                ADMNO = "",
                CLASS = "",
                REASONFORLEAVING = "",
                CLASSTEACHER = "",
                TOD = "",
                PRINCIPAL = "",
                LEAVINGDATE = now,
                RETURNDATE = now.AddHours(4), // Adjust as needed
                SIGNATUREDATE = now,
                TODDATE = now,
                SIGNDATE = now
            };

            return View(model);
        }

        // POST: Leaveout_sheet/Create
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
            if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
            {
                return BadRequest("Please enter at least 2 characters.");
            }

            var student = await _context.Leaveout_sheet
                .Where(s => s.STUDENTNAME.ToUpper().Contains(query.ToUpper()) || 
                           s.ADMNO.ToUpper().Contains(query.ToUpper()))
                .Select(s => new { s.STUDENTNAME, s.ADMNO, s.CLASS })
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Json(student);
        }

        // GET: Leaveout_sheet/ViewCertificate/5
        
        public async Task<IActionResult> ViewCertificate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveout_sheet = await _context.Leaveout_sheet.FindAsync(id);
            if (leaveout_sheet == null || string.IsNullOrEmpty(leaveout_sheet.CertificatePath))
            {
                return NotFound();
            }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, leaveout_sheet.CertificatePath);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "application/pdf");
        }

        // POST: Leaveout_sheet/UploadCertificate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> UploadCertificate(int id, IFormFile certificate)
        {
            if (certificate == null || certificate.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var leaveout_sheet = await _context.Leaveout_sheet.FindAsync(id);
            if (leaveout_sheet == null)
            {
                return NotFound();
            }

            // Create uploads directory if it doesn't exist
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "certificates");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}_{certificate.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await certificate.CopyToAsync(stream);
            }

            // Update the certificate path in the database
            leaveout_sheet.CertificatePath = Path.Combine("uploads", "certificates", uniqueFileName);
            _context.Update(leaveout_sheet);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}