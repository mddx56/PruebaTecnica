using PruebaTecnica.Entities;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos
{
    public class MaintenanceTaskCreateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; }
        public int StoreId { get; set; }
        public required string UserId { get; set; }
    }
}
