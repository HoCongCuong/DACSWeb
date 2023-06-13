using AspNetCoreHero.ToastNotification.Abstractions;
using BlogWeb.Data;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        public INotyfService _notification { get; }
        private readonly UserManager<ApplicationUser> _userManager;
 
        public PostController(ApplicationDbContext context, INotyfService notification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _notification = notification;
            _userManager = userManager;
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

            var comments = _context.comments
                                   .Where(c => c.postId == post.Id && c.ApplicationUserId == post.ApplicationUserId)
                                   .ToList();

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
                CategoryName = post.categorys!.CategoryName,
                Comments = comments
            };
            return View(vm);
        }

        
        [HttpPost("[controller]/{slug}")]
        public async Task<IActionResult> detail(BlogPostvm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var loggedInUser = await _userManager.GetUserAsync(User);

            var cmts = new comment();
            cmts.postId = vm.postId;
            cmts.cmt = vm.Content;
            cmts.ApplicationUserId = loggedInUser!.Id;
            await _context.comments!.AddAsync(cmts);
            await _context.SaveChangesAsync();
            _notification.Success("Comment Created Successfully");
            return RedirectToAction("index", "Home");
        }

    }
}
