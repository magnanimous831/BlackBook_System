using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
namespace BlackBook_System.Models
{
    public class Teachers_List
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        [StringLength(100, MinimumLength = 3)]
        public required string FullName { get; set; }
        [Display(Name = "Gender")]
        [StringLength(50)]
        public required string Gender { get; set; }
        public required string Class { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Subjects field is required")]
        public required string Subjects { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 13 digits")]
        public required string Phonenumber { get; set; }

    }
}
