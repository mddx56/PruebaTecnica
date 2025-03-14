using Microsoft.AspNetCore.Identity;

namespace PruebaTecnica.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
