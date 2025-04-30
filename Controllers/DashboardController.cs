using Microsoft.AspNetCore.Mvc;
using BlackBook_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BlackBook_System.Models;

namespace BlackBook_System.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BlackBook_SystemContext _context;

        public DashboardController(BlackBook_SystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Get all statistics
                var enrolledStudents = await _context.StudentsEnrollment.CountAsync();
                var leaveoutSheets = await _context.Leaveout_sheet.CountAsync();
                var occurrences = await _context.Occurrences.CountAsync();
                var disciplineCases = await _context.Discipline.CountAsync();

                // Create a view model with all statistics
                var dashboardStats = new DashboardStats
                {
                    EnrolledStudents = enrolledStudents,
                    LeaveoutSheets = leaveoutSheets,
                    Occurrences = occurrences,
                    DisciplineCases = disciplineCases
                };

                return View(dashboardStats);
            }
            catch
            {
                // Return empty stats in case of error
                return View(new DashboardStats());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaveoutStats()
        {
            try
            {
                var leaveouts = await _context.Leaveout_sheet
                    .GroupBy(l => l.REASONFORLEAVING)
                    .Select(g => new
                    {
                        Reason = g.Key,
                        Count = g.Count()
                    })
                    .ToListAsync();

                return Json(leaveouts);
            }
            catch
            {
                return StatusCode(500, new { error = "Error retrieving leaveout statistics" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyLeaveouts()
        {
            try
            {
                var monthlyData = await _context.Leaveout_sheet
                    .GroupBy(l => new { l.LEAVINGDATE.Year, l.LEAVINGDATE.Month })
                    .Select(g => new
                    {
                        Month = $"{g.Key.Year}-{g.Key.Month}",
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Month)
                    .ToListAsync();

                return Json(monthlyData);
            }
            catch
            {
                return StatusCode(500, new { error = "Error retrieving monthly leaveout data" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClassWiseLeaveouts()
        {
            try
            {
                var classData = await _context.Leaveout_sheet
                    .GroupBy(l => l.CLASS)
                    .Select(g => new
                    {
                        Class = g.Key,
                        Count = g.Count()
                    })
                    .ToListAsync();

                return Json(classData);
            }
            catch
            {
                return StatusCode(500, new { error = "Error retrieving class-wise leaveout data" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDisciplineStats()
        {
            try
            {
                var disciplineData = await _context.Discipline
                    .GroupBy(d => d.CASE_STATUS)
                    .Select(g => new
                    {
                        Status = g.Key ?? "No Status",
                        Count = g.Count()
                    })
                    .ToListAsync();

                return Json(disciplineData);
            }
            catch
            {
                return StatusCode(500, new { error = "Error retrieving discipline statistics" });
            }
        }
    }
} 