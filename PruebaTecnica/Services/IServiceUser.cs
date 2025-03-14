using PruebaTecnica.Entities;

namespace PruebaTecnica.Services
{
    public interface IServiceUser
    {
        Task<User?> ObtenerUsuario();
    }
}
