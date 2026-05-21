using Microsoft.AspNetCore.Mvc;
using ElectriStore_BaseProject.DTOs.Login;
using ElectriStore_BaseProject.DTOs.Registers;
using ElectriStore_BaseProject.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.Data;


namespace ElectriStore_BaseProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequestDTO model) {
            //
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            LoginResultDTO result = await _userService.LoginAsync(model);

            // if login successfully -> provider that account a cookie
            if (result.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.FullName ?? "User"),
                    new Claim(ClaimTypes.Email, result.Email ?? ""),
                    new Claim(ClaimTypes.Role, result.Role ?? "User")
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // IsPersistent == true -> permanent, IsPersistent == false-> , session  
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

                if (result.Role == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin"});
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "Đăng nhập thất bại");
            return View(model); 
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //public async Task<ActionResult> Register(RegisterRequest registerRequest)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(registerRequest);
        //    }


        //}
    }

}
