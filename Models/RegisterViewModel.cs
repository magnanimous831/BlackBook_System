using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class RegisterViewModel
    {
        [Required]
<<<<<<< HEAD
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
=======
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
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
    }
} 