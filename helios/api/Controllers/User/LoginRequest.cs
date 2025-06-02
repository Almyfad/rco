using System.ComponentModel.DataAnnotations;

namespace Helios.Controllers.User
{
    public record LoginRequest
    {
        [Required]
        public required string Email { get; init; }
        [Required]
        public required string Password { get; init; }
    }
}
