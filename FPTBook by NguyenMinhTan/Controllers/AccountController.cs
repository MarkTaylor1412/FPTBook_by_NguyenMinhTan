using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FPTBook_by_NguyenMinhTan.Models.ViewModels;

namespace FPTBook_by_NguyenMinhTan.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;

        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMng, SignInManager<IdentityUser> signInMng)
        {
            userManager = userMng;
            signInManager = signInMng;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Username);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel.ReturnUrl ?? "/admin");
                    }
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(loginModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
