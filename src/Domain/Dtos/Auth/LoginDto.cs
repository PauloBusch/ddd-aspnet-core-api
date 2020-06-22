using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        [StringLength(100, ErrorMessage = "Email require {1} maxmium characters")]
        public string Email { get; set; }
    }
}
