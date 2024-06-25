using System.ComponentModel.DataAnnotations;

namespace M008_Authentication.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string? Username { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
