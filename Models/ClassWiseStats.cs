using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class ClassWiseStats
    {
        [Key]
        public int id { get; set; }
        public required string Class { get; set; }
        public int StudentCount { get; set; }
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
    }
} 