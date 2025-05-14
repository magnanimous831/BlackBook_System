using System.ComponentModel.DataAnnotations;
namespace BlackBook_System.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public required string County { get; set; }
        public required string SubCounty { get; set; }
        public required string Ward { get; set; }
    }
}
