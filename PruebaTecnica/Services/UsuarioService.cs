using Microsoft.AspNetCore.Identity;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Services
{
    public class UsuarioService : IServiceUser
    {
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor contextAccessor;

        public UsuarioService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            this.userManager = userManager;
            this.contextAccessor = contextAccessor;
        }

        public async Task<User?> ObtenerUsuario()
        {
            var emailClaim = contextAccessor.HttpContext!
                                .User.Claims.Where(x => x.Type == "email").FirstOrDefault();

            if (emailClaim is null)
            {
                return null;
            }

            var email = emailClaim.Value;
            return await userManager.FindByEmailAsync(email);

        }
    }
}
