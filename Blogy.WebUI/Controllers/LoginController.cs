
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    
    
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (p.Username != null && p.Passoword != null)
            {

                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Passoword, false, false);

                if ((result.Succeeded))
                {
                    var deger = await _userManager.FindByNameAsync(p.Username);
                    if (deger.Status != false)
                    {
                        return RedirectToAction("MyBlogList", "Blog");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Siteye Erişiminiz Kısıtlanmıştır.Lütfen Yöneticiniz İle İletişime Geçiniz.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalı");
                }

            }
            else
            {
                ModelState.AddModelError("", "Lütfen Boş Alan Geçmeyiniz.");
            }
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
