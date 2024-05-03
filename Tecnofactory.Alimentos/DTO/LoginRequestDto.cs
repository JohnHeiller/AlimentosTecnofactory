using System.ComponentModel.DataAnnotations;

namespace Tecnofactory.Alimentos.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
