using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos
{
    public class EditClaimDto
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email es requerido")]
        public required string Email { get; set; }
    }
}
