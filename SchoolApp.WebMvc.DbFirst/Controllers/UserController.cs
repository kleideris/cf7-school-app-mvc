using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.WebMvcDbFirst.DTO;
using SchoolApp.WebMvcDbFirst.Services;
using System.Security.Claims;

namespace SchoolApp.WebMvcDbFirst.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationService _applicationService;

        public UserController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]   // its the default if i dont give anything
        public IActionResult Login()
        {
            ClaimsPrincipal principal = HttpContext.User;
            if (!principal.Identity!.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "User");   //Dashboard TODO
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDTO credentials)
        {
            var user = await _applicationService.UserService.VerifyAndGetUserAsync(credentials);

            if(user is null)
            {
                ViewData["ValidateMessage"] = "Error. Username / Password invalid";
                    return View();
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username!),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()!)
            };

            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new()
            {
                AllowRefresh = true,
                IsPersistent = credentials.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), properties);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        // TODO: StudentController, CourseController
    }
}
