using Client.Models;
using Client.Repository.Interface;
using Common.BO;
using Common.DAO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _rp;

        public HomeController(IUserRepository rp)
        {
            _rp = rp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            UserForLogin user = new UserForLogin();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserForLogin userFL)
        {
            if (ModelState.IsValid)
            {
                User userLogin = await _rp.LoginAsync(userFL);
                if (userLogin == null)
                {
                    TempData["Alert"] = "Login Failure ! Invalid Username or Password !";
                    return View();
                }

                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userLogin.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, userLogin.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, userLogin.Role));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("DisplayName", userLogin.DisplayName);
                TempData["Alert"] = "Welcome " + userLogin.UserName;

                return RedirectToAction(nameof(Index));
            }
            TempData["Alert"] = "Login Failure ! Invalid Username or Password !";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("IsLoggedIn", "false");
            HttpContext.Session.SetString("DisplayName", "");
            TempData["Alert"] = "Logout Successfully !";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
