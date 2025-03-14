namespace PruebaTecnica.Dtos
{
    public class UpdateUserDto
    {
        public required string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
