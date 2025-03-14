namespace PruebaTecnica.Dtos
{
    public class ResponseAuthDto
    {
        public required string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
