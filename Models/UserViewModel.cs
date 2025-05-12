using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackBook_System.Models
{
    public class UserViewModel
    {
        [Required]
        public required string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public required string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public required string Email { get; set; }

        [Display(Name = "Assigned Roles")]
        public List<string> Roles { get; init; } = new();
    }

    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "User Role")]
        public string Role { get; set; } = string.Empty;

        public List<RoleViewModel> AvailableRoles { get; init; } = new();

        public CreateUserViewModel() { }

        public CreateUserViewModel(List<RoleViewModel> availableRoles)
        {
            AvailableRoles = availableRoles;
        }
    }

    public class RoleViewModel
    {
        public required string RoleName { get; set; }
    }
}
