using System;
using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class Discipline
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Date of Incident")]
        [DataType(DataType.Date)]
        public DateTime DATE { get; set; }

        [Required]
        [Display(Name = "Admission Number")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Use uppercase letters and numbers only.")]
        [StringLength(20, MinimumLength = 3)]
        public string ADMNO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Student Name")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        [StringLength(100, MinimumLength = 3)]
        public string STUDENTNAME { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Class")]
        [StringLength(50)]
        public string CLASS { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Indiscipline Case")]
        [StringLength(300, ErrorMessage = "Too long (max 300 characters).")]
        public string INDISCIPLINECASE { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Audited By")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        [StringLength(100, MinimumLength = 3)]
        public string AUDITED_BY { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Audit Timestamp")]
        [DataType(DataType.DateTime)]
        public DateTime AUDITED_DATETIME { get; set; }

        [Display(Name = "Action Taken")]
        [StringLength(300)]
        public string? ACTION_TAKEN { get; set; }

        [Display(Name = "Case Status")]
        [StringLength(50)]
        [RegularExpression(@"^(Open|Closed|Pending)$", ErrorMessage = "Status must be Opened, In-Progress, Closed, or Pending.")]
        public string? CASE_STATUS { get; set; }
    }
}
