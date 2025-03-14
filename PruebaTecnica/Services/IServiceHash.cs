using PruebaTecnica.Dtos;
namespace PruebaTecnica.Services
{
    public interface IServiceHash
    {
        ResultHashDto Hash(string input);
        ResultHashDto Hash(string input, byte[] sal);
    }
}
