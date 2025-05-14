using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Data;
using BlackBook_System.Models;
using System.Threading.Tasks;
using System.Linq;

namespace BlackBook_System.Controllers
{
    public class ReportsController : Controller
    {
        private readonly BlackBookDbContext _context;

        public ReportsController(BlackBookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reportStats = new ReportStats
            {
                TotalStudents = await _context.StudentsEnrollment.CountAsync(),
                TotalTeachers = await _context.Teachers_List.CountAsync(),
                TotalLeaveouts = await _context.Leaveout_sheet.CountAsync(),
                TotalDisciplineCases = await _context.Discipline.CountAsync(),
                TotalOccurrences = await _context.Occurrences.CountAsync()
            };

            return View(reportStats);
        }

        [HttpGet]
        public async Task<IActionResult> StudentReport()
        {
            var students = await _context.StudentsEnrollment
                .OrderBy(s => s.CLASSADMITTED)
                .ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> LeaveoutReport()
        {
            var leaveouts = await _context.Leaveout_sheet
                .OrderByDescending(l => l.LEAVINGDATE)
                .ToListAsync();
            return View(leaveouts);
        }

        [HttpGet]
        public async Task<IActionResult> DisciplineReport()
        {
            var disciplineCases = await _context.Discipline
                .OrderByDescending(d => d.DATE)
                .ToListAsync();
            return View(disciplineCases);
        }

        [HttpGet]
        public async Task<IActionResult> OccurrenceReport()
        {
            var occurrences = await _context.Occurrences
                .OrderByDescending(o => o.DateTimeOccurred)
                .ToListAsync();
            return View(occurrences);
        }

        [HttpGet]
        public async Task<IActionResult> TeacherReport()
        {
            var teachers = await _context.Teachers_List
                .OrderBy(t => t.FullName)
                .ToListAsync();
            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> ClassWiseReport()
        {
            var classStats = await _context.StudentsEnrollment
                .GroupBy(s => s.CLASSADMITTED)
                .Select(g => new ClassWiseStats
                {
                    Class = g.Key,
                    StudentCount = g.Count(),
                    MaleCount = g.Count(s => s.GENDER == "Male"),
                    FemaleCount = g.Count(s => s.GENDER == "Female")
                })
                .OrderBy(s => s.Class)
                .ToListAsync();

            return View(classStats);
        }
    }
} 