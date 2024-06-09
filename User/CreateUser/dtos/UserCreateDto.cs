using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Dtos {

public class UserCreateDto
{
        [Required(ErrorMessage ="Cannot be null or empty")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Cannot be null or empty")]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Cannot be null or empty")]

        [EmailAddress(ErrorMessage = "Podany adres email nie jest poprawny.")]
        public string? Email { get; set; }
}
public class UpdatePasswordDto
    {

        [Required]
        public string? oldPassword { get; set; }

        [Required]
        public string? newPassword { get; set; }

    }
}
