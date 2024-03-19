using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userMenager;

        public RegisterController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterViewModel createRegister)
        {
            AppUser appUser=new AppUser()
            {
                Name=createRegister.Name,
                Surname=createRegister.Surname,
                Email=createRegister.Email,
                UserName=createRegister.Username,
                Description="a",
                ImageUrl="b"
            };

            var result =await _userMenager.CreateAsync(appUser,createRegister.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
      
    }
}
