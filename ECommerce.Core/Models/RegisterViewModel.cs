using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
