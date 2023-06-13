using BlogWeb.Data;
using BlogWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Utilites
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext context,
                               UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (!_roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteUser)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FullName = "AdminPro"
                }, "123456Av@").Wait();

                var appUser = _context.ApplicationUsers!.FirstOrDefault(x => x.Email == "admin@gmail.com");
                if (appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult();
                }

                var listOfPages = new List<Models.Page>()
                {
                    new Models.Page()
                    {
                         Title = "About Us",
                        Slug = "about"
                    },
                    new Models.Page()
                    {
                        Title = "Contact Us",
                        Slug = "contact"
                    },
                    new Models.Page()
                    {
                        Title = "Privacy Policy",
                        Slug = "privacy"
                    }
                 };

                _context.Pages!.AddRange(listOfPages);

                var setting = new Setting
                {
                    SiteName = "Site Name",
                    Title = "Site Title",
                    ShortDescription = "Short Description of site"
                };

                _context.Settings!.Add(setting);
                _context.SaveChanges();

            }
        }
    }
}
