using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StaffCoreRD.Models;

namespace StaffCoreRD.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                  SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var resultado = await _userManager.CreateAsync(user, model.Password);

            if (resultado.Succeeded)
            {
                // ¿Es el primer usuario del sistema?
                bool esPrimerUsuario = _userManager.Users.Count() == 1;
                string rol = esPrimerUsuario ? "Administrador" : "Viewer";
                await _userManager.AddToRoleAsync(user, rol);

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in resultado.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var resultado = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (resultado.Succeeded)
                return RedirectToAction("Index", "Home");

            if (resultado.IsLockedOut)
                ModelState.AddModelError(string.Empty, "Cuenta bloqueada temporalmente por múltiples intentos fallidos. Intenta de nuevo en unos minutos.");
            else
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas. Verifica tu correo y contraseña.");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}