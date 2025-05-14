using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
<<<<<<< HEAD
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
=======
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
} 