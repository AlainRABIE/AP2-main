using ASPBookProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ASPBookProject.ViewModels;

namespace ASPBookProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Medecin> _signInManager;
        private readonly UserManager<Medecin> _userManager;

        public AccountController(SignInManager<Medecin> signInManager, UserManager<Medecin> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Patient");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Identifiant = user.Id
            };

            return View("EditProfil", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfil(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProfil", model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("EditProfil", model);
        }
        [HttpGet]
        public IActionResult FAQ()
        {
            return View("~/Views/FAQ/FAQ.cshtml"); 
        }
        [HttpGet]
        public IActionResult Guide()
        {
            return View("~/Views/Guide/Guide.cshtml");
        }
    }

}