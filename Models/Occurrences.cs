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
        public required string TeacherOnDuty { get; set; }//Teacher on duty
        public required string DAILYACTIVITY { get; set; }
        public required string PLACE { get; set; }
        public required string RECORDED_BY { get; set; }
        public required string REMARKS { get; set; }

    }
}
