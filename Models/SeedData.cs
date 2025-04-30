using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlackBook_System.Data;
using System;
using System.Linq;

namespace BlackBook_System.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlackBook_SystemContext(
                serviceProvider.GetRequiredService<DbContextOptions<BlackBook_SystemContext>>()))
            {
                // Seed Discipline records
                if (!context.Discipline.Any())
                {
                    context.Discipline.AddRange(
                        new Discipline
                        {
                            DATE = DateTime.Parse("2025-04-25"),
                            ADMNO = "ADM001",
                            STUDENTNAME = "John Doe",
                            CLASS = "Form 2 Blue",
                            INDISCIPLINECASE = "Late to class",
                            AUDITED_BY = "Mr. Smith",
                            AUDITED_DATETIME = DateTime.Parse("2025-04-25 08:30"),
                            ACTION_TAKEN = "Punishment",
                            CASE_STATUS = "Resolved"
                        },
                        new Discipline
                        {
                            DATE = DateTime.Parse("2025-04-24"),
                            ADMNO = "ADM002",
                            STUDENTNAME = "Jane Mwangi",
                            CLASS = "Form 3 Red",
                            INDISCIPLINECASE = "No homework",
                            AUDITED_BY = "Ms. Achieng",
                            AUDITED_DATETIME = DateTime.Parse("2025-04-24 10:15"),
                            ACTION_TAKEN = "Punishment",
                            CASE_STATUS = "Resolved"
                        },
                        new Discipline
                        {
                            DATE = DateTime.Parse("2025-04-23"),
                            ADMNO = "ADM003",
                            STUDENTNAME = "Mark Otieno",
                            CLASS = "Form 1 Green",
                            INDISCIPLINECASE = "Noise making",
                            AUDITED_BY = "Deputy Principal",
                            AUDITED_DATETIME = DateTime.Parse("2025-04-23 12:00"),
                            ACTION_TAKEN = "Punishment",
                            CASE_STATUS = "Resolved"
                        }
                    );
                }

                // Seed StudentsEnrollment records
                if (!context.StudentsEnrollment.Any())
                {
                    context.StudentsEnrollment.AddRange(
                        new StudentsEnrollment
                        {
                            ADMNO = "ADM001",
                            STUDENTNAME = "John Doe",
                            GENDER = "Male",
                            DOB = DateTime.Parse("2009-06-15"),
                            CLASSADMITTED = "Form 2 Blue",
                            ADMISSIONDATE = DateTime.Parse("2023-01-10"),
                            GUARDIAN_NAME = "Mary Doe",
                            CONTACTNUMBER = "0700000001",
                            ADDRESS = "Nairobi",
                            County = "Nairobi County",
                            SubCounty = "Central SubCounty",
                            CertificateName = "certificate_1.pdf"
                        },
                        new StudentsEnrollment
                        {
                            ADMNO = "ADM002",
                            STUDENTNAME = "Jane Mwangi",
                            GENDER = "Female",
                            DOB = DateTime.Parse("2008-08-20"),
                            CLASSADMITTED = "Form 3 Red",
                            ADMISSIONDATE = DateTime.Parse("2022-01-12"),
                            GUARDIAN_NAME = "James Mwangi",
                            CONTACTNUMBER = "0700000002",
                            ADDRESS = "Mombasa",
                            County = "Mombasa County",
                            SubCounty = "Mombasa Island",
                            CertificateName = "certificate_2.pdf"
                        },
                        new StudentsEnrollment
                        {
                            ADMNO = "ADM003",
                            STUDENTNAME = "Mark Otieno",
                            GENDER = "Male",
                            DOB = DateTime.Parse("2010-02-05"),
                            CLASSADMITTED = "Form 1 Green",
                            ADMISSIONDATE = DateTime.Parse("2024-01-15"),
                            GUARDIAN_NAME = "Sarah Otieno",
                            CONTACTNUMBER = "0700000003",
                            ADDRESS = "Kisumu",
                            County = "Kisumu County",
                            SubCounty = "Kisumu West",
                            CertificateName = "certificate_3.pdf"
                        }
                    );
                }

                // Seed Leaveout_sheet records
                if (!context.Leaveout_sheet.Any())
                {
                    context.Leaveout_sheet.AddRange(
                        new Leaveout_sheet
                        {
                            STUDENTNAME = "John Doe",
                            ADMNO = "ADM001",
                            CLASS = "Form 2 Blue",
                            LEAVINGDATE = DateTime.Parse("2025-04-20"),
                            REASONFORLEAVING = "Medical Appointment",
                            RETURNDATE = DateTime.Parse("2025-04-21"),
                            CLASSTEACHER = "Mr. Ochieng",
                            SIGNATUREDATE = DateTime.Parse("2025-04-20"),
                            TOD = "Ms. Wanjiku",
                            TODDATE = DateTime.Parse("2025-04-20"),
                            PRINCIPAL = "Mr. Maina",
                            SIGNDATE = DateTime.Parse("2025-04-20")
                        },
                        new Leaveout_sheet
                        {
                            STUDENTNAME = "Jane Mwangi",
                            ADMNO = "ADM002",
                            CLASS = "Form 3 Red",
                            LEAVINGDATE = DateTime.Parse("2025-04-18"),
                            REASONFORLEAVING = "Family Emergency",
                            RETURNDATE = DateTime.Parse("2025-04-19"),
                            CLASSTEACHER = "Mrs. Njeri",
                            SIGNATUREDATE = DateTime.Parse("2025-04-18"),
                            TOD = "Mr. Mutiso",
                            TODDATE = DateTime.Parse("2025-04-18"),
                            PRINCIPAL = "Mr. Maina",
                            SIGNDATE = DateTime.Parse("2025-04-18")
                        }
                    );
                }

                // Seed Occurrences records with ID as primary key
                if (!context.Occurrences.Any())
                {
                    context.Occurrences.AddRange(
                        new Occurrences
                        {
                            DateTimeOccurred = DateTime.Parse("2025-04-25T08:00:00"),
                            TeacherOnDuty = "Michael",
                            DAILYACTIVITY = "Math Class",
                            PLACE = "Room 101",
                            RECORDED_BY = "Mr. Smith",
                            REMARKS = "Students were attentive"
                        },
                        new Occurrences
                        {
                            DateTimeOccurred = DateTime.Parse("2025-04-24T09:00:00"),
                            TeacherOnDuty = "Monicah",
                            DAILYACTIVITY = "Science Lab",
                            PLACE = "Lab 3",
                            RECORDED_BY = "Ms. Achieng",
                            REMARKS = "Lab session was productive"
                        },
                        new Occurrences
                        {
                            DateTimeOccurred = DateTime.Parse("2025-04-23T10:00:00"),
                            TeacherOnDuty = "Moris",
                            DAILYACTIVITY = "History Lecture",
                            PLACE = "Room 202",
                            RECORDED_BY = "Mrs. Wanjiku",
                            REMARKS = "Discussion on ancient civilizations"
                        }
                    );
                }

                // Save everything
                context.SaveChanges();
            }
        }
    }
}
