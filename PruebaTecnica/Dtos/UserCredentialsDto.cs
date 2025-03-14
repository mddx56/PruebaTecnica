using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos
{
    public class UserCredentialsDto
    {
        [Required(ErrorMessage ="Email es requerido")]
        [EmailAddress]
        public required string Email { get; set; }
        [Required(ErrorMessage ="Contraseña es requerida")]
        public string? Password { get; set; }
    }
}
