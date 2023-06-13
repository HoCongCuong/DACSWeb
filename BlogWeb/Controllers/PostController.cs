using AspNetCoreHero.ToastNotification.Abstractions;
using BlogWeb.Data;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        public INotyfService _notification { get; }

        public PostController(ApplicationDbContext context, INotyfService notification)
        {
            _context = context;
            _notification = notification;
        }
        [HttpGet("[controller]/{slug}")]
        public IActionResult detail(string slug)
        {
            if (slug == "")
            {
                _notification.Error("Post not found");
                return View();
            }
            var post = _context.Posts!.Include(x => x.ApplicationUser)
                                      .Include(x => x.categorys)
                                      .FirstOrDefault(x => x.Slug == slug);
            if (post == null)
            {
                _notification.Error("Post not found");
                return View();
            }
            var vm = new BlogPostvm()
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.ApplicationUser!.FullName,
                CreatedDate = post.CreatedDate,
                ThumbnailUrl = post.ThumbnailUrl,
                imgUser = post.ApplicationUser!.imgUser,
                Description = post.Description,
                ShortDescription = post.ShortDescription,
                CategoryName = post.categorys!.CategoryName
            };



            return View(vm);
        }


    }
}
