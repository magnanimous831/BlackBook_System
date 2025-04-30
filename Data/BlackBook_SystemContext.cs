using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Models;

namespace BlackBook_System.Data
{
    public class BlackBook_SystemContext : DbContext
    {
        public BlackBook_SystemContext (DbContextOptions<BlackBook_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<BlackBook_System.Models.Discipline> Discipline { get; set; } = default!;
        public DbSet<BlackBook_System.Models.StudentsEnrollment> StudentsEnrollment { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Leaveout_sheet> Leaveout_sheet { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Occurrences> Occurrences { get; set; } = default!;
    }
}
