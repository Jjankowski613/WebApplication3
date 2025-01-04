using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Możesz dodać własne pola dla użytkownika, np.:
        public string FullName { get; set; }
        public string Movie { get; set; }

    }
}
