using AspNetCoreHero.ToastNotification.Abstractions;
using BlogWeb.Models;
using BlogWeb.Utilites;
using BlogWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogWeb.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public INotyfService _notification { get; }

        public AccountController(UserManager<ApplicationUser> userManager,
                                    IWebHostEnvironment webHostEnvironment,
                                    SignInManager<ApplicationUser> signInManager,
                                    INotyfService notyfService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notification = notyfService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity!.IsAuthenticated)
            {
                return View(new loginvm());
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(loginvm vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == vm.Username);
            if (existingUser == null)
            {
                _notification.Error("Username does not exist");
                return View(vm);
            }
            var verifyPassword = await _userManager.CheckPasswordAsync(existingUser, vm.Password);
            if (!verifyPassword)
            {
                _notification.Error("Password does not match");
                return View(vm);
            }
            await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberMe, true);
            _notification.Success("Login Successful");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Registervm());
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registervm vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            var checkUserByEmail = await _userManager.FindByEmailAsync(vm.Email);
            if (checkUserByEmail != null)
            {
                _notification.Error("Email already exists");
                return View(vm);
            }
            var checkUserByFullName = await _userManager.FindByNameAsync(vm.FullName);
            if (checkUserByFullName != null)
            {
                _notification.Error("Name already exists");
                return View(vm);
            }

            

            var applicationUser = new ApplicationUser()
            {
                Email = vm.Email,
                UserName = vm.Email,
                FullName = vm.FullName,
            };

            var result = await _userManager.CreateAsync(applicationUser, vm.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, WebsiteRoles.WebsiteUser);
                _notification.Success("User registered successfully");
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            _notification.Success("You are logged out successfully");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet("AccessDenied")]
        [Authorize]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                // Xử lý khi không tìm thấy người dùng
                return NotFound();
            }

            var model = new Uservm
            {
                UserName = user.UserName,
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                phone = user.PhoneNumber,
                imgUser = user.imgUser
                // Thêm các thuộc tính khác của ApplicationUser cần hiển thị
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Uservm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user == null)
                {
                    // Xử lý khi không tìm thấy người dùng
                    return NotFound();
                }

                // Cập nhật thông tin người dùng từ model
                user.FullName = model.FullName;
                user.Email = model.Email;
                user.PhoneNumber = model.phone;

                if (model.Thumbnail != null)
                {
                    user.imgUser = UploadImage(model.Thumbnail);
                    _notification.Success("Post updated succesfully");
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
            }

            // Model không hợp lệ, quay trở lại trang Edit và hiển thị lỗi
            return View(model);
        }

        private string UploadImage(IFormFile file)
        {
            string uniqueFileName = "";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "thumbnails");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }


    }
}
