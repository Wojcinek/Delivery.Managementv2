using Delivery.Management.MVC.Contracts;
using Delivery.Management.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Management.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UsersController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
            if (isLoggedIn) 
                return LocalRedirect(returnUrl);

            ModelState.AddModelError("", "Log in Attempt Failed. Please try Again");
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        
    }
}
