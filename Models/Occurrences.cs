using System;
using System.ComponentModel.DataAnnotations;
namespace BlackBook_System.Models
{
    public class Occurrences
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Date and Time Occurred")]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeOccurred { get; set; }

        [Display(Name = "TeacherOnDuty")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        [StringLength(100, MinimumLength = 3)]
        public required string TeacherOnDuty { get; set; }//Teacher on duty

        [StringLength(500)]
        public required string DAILYACTIVITY { get; set; }

        public required string PLACE { get; set; }

        [Display(Name = "Recordedby")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        [StringLength(100, MinimumLength = 3)]
        public required string RECORDED_BY { get; set; }

        [StringLength(500)]
        public required string REMARKS { get; set; }

    }
}
