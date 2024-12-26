using Microsoft.AspNetCore.Identity;

namespace DreamWedds.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
