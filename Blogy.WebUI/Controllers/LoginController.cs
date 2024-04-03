using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (p.Username!=null && p.Passoword!=null)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Passoword,false,false);
                if ((result.Succeeded))
                {
                    return RedirectToAction("BlogList", "Blog");
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
    }
}
