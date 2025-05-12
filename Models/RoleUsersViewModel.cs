using System.ComponentModel.DataAnnotations;
namespace BlackBook_System.Models
{
    public class RoleUsersViewModel
    {
        [Key]
        public int id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<string> Users { get; set; } = new List<string>();
    }
}
