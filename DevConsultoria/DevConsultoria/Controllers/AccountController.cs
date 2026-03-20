using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using DevConsultoria.Models;

namespace DevConsultoria.Controllers
{
    public class AccountController : Controller
    {
        private const string AdminUser = "admin";
        private const string AdminPass = "admin123";

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (model.Usuario == AdminUser && model.Senha == AdminPass)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Usuario),
                    new Claim(ClaimTypes.Role, "TechLider"),
                    new Claim("FullName", "Tech Líder"),
                    new Claim("LoginTime", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { IsPersistent = false });

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Dashboard", "Admin");
            }

            TempData["Erro"] = "Usuário ou senha incorretos.";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}