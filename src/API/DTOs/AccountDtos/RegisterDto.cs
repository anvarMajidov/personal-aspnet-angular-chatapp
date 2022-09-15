using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AccountDtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
