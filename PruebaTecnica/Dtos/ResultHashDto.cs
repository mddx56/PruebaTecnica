namespace PruebaTecnica.Dtos
{
    public class ResultHashDto
    {
        public required string Hash { get; set; }
        public required byte[] Sal { get; set; }
    }
}
