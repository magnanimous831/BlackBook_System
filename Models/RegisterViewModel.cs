using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public required string FullName { get; set; }
        public required string Gender { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public required string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Role")]
        public required string Role { get; set; }

        [Required]
        [Display(Name = "Subjects")]
        public required string Subjects { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public required string Phonenumber { get; set; }
    }
} 