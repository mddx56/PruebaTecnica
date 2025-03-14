using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entities
{
    public class MaintenanceTask
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; }
        public string? Description { get; set; } 
        public bool Completed { get; set; }
        public DateTime? CreatedAt { get; set; } 
        public int StoreId { get; set; }
        public Store? Store { get; set; }
        public required string UserId { get; set; }
        public User? User { get; set; }
    }
}
