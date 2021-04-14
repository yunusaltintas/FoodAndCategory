using FoodAndGo.Data.ViewModels;
using FoodAndGo.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FoodAndGo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ViewModelLogin viewModelLogin)
        {
            bool loginsucces = await _loginService.LoginAsync(viewModelLogin);
            if (!loginsucces)
            {
                return RedirectToAction("Category/Index");
            }

            List<Claim> userClaims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name, "haci" ),
            new Claim(ClaimTypes.Email,viewModelLogin.Email),
            };

            var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties()
            {
                IsPersistent = viewModelLogin.RememberMe
            });

            return RedirectToAction("Index","Category");
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}
