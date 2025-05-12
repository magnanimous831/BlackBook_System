using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackBook_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlackBook_System.Data
{
    public class BlackBookDbContext : IdentityDbContext<IdentityUser>
    {
        public BlackBookDbContext(DbContextOptions<BlackBookDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints here
            modelBuilder.Entity<Discipline>()
                .HasKey(d => d.ID);

            modelBuilder.Entity<StudentsEnrollment>()
                .HasKey(s => s.EnrollmentID);

            modelBuilder.Entity<Leaveout_sheet>()
                .HasKey(l => l.LEAVEOUTID);

            modelBuilder.Entity<Occurrences>()
                .HasKey(o => o.id);

            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Teachers_List>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<User_Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<BlackBook_System.Models.Discipline> Discipline { get; set; } = default!;
        public DbSet<BlackBook_System.Models.StudentsEnrollment> StudentsEnrollment { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Leaveout_sheet> Leaveout_sheet { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Occurrences> Occurrences { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Location> Location { get; set; } = default!;
        public DbSet<BlackBook_System.Models.Teachers_List> Teachers_List { get; set; } = default!;
        public DbSet<BlackBook_System.Models.User_Role> User_Role { get; set; } = default!;
    }
}
