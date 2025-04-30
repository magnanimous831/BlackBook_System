using System;

namespace BlackBook_System.Models
{
    public class DashboardStats
    {
        public int EnrolledStudents { get; set; }
        public int LeaveoutSheets { get; set; }
        public int Occurrences { get; set; }
        public int DisciplineCases { get; set; }

        public DashboardStats()
        {
            EnrolledStudents = 0;
            LeaveoutSheets = 0;
            Occurrences = 0;
            DisciplineCases = 0;
        }
    }
} 