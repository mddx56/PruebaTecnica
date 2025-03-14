using PruebaTecnica.Entities;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos
{
    public class MaintenanceTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int StoreId { get; set; }
        public required string UserId { get; set; }
    }
}
