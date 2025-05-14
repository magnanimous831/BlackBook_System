using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using System.IO;

namespace BlackBook_System.Models
{
    public class StudentsEnrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        [Display(Name = "Admission Number")]
        public required string ADMNO { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public required string STUDENTNAME { get; set; }

        [Required]
        public required string GENDER { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Class Admitted")]
        public required string CLASSADMITTED { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Admission Date")]
        public DateTime ADMISSIONDATE { get; set; }

        [Required]
        [Display(Name = "Guardian Name")]
        public required string GUARDIAN_NAME { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public required string CONTACTNUMBER { get; set; }
        [Required]
        [Display(Name = "County")]
        public required string County { get; set; }

        [Required]
        [Display(Name = "SubCounty")]
        public required string SubCounty { get; set; }
        public required string Ward { get; set; }

        // Removed the CertificatePath field
        // Placeholder for displaying uploaded certificate/document name
        [Display(Name = "Certificate Name")]
        public string? CertificateName { get; set; }
    }
}
