using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entities
{
    public class Store
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; }
        public List<MaintenanceTask> MaintenanceTasks { get; set; } = [];
    }
}
