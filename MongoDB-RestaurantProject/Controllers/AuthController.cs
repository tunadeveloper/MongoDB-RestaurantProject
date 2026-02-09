using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestaurantProject.DataTransferObject.LoginDTOs;
using MongoDB_RestaurantProject.Services.AdminService;
using System.Security.Claims;

namespace MongoDB_RestaurantProject.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAdminService _adminService;

        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var admin = await _adminService.LoginAsync(model.Email, model.Password);

            if (admin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Name, admin.Username),
                    new Claim(ClaimTypes.Email, admin.Email)
                };

             var userIdentity = new ClaimsIdentity(claims, "CookieAuth");
             var principal = new ClaimsPrincipal(userIdentity);
             await HttpContext.SignInAsync("CookieAuth", principal);
             return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}