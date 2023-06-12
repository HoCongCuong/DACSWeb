using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public string? imgUser { get; set; }

        //relation
        public List<Post>? Posts { get; set; }
    }
}
