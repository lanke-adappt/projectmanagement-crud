using System.ComponentModel.DataAnnotations;

namespace Task1.Api.Models
{
    public class UserLoginRequest
    {
        
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
