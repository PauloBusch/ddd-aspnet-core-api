using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name require {1} maxmium characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        [StringLength(100, ErrorMessage = "Email require {1} maxmium characters")]
        public string Email { get; set; }
    }
}
