using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents._LayoutComponent
{
    public class _NavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _NavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.values = _userManager.Users.First().UserName;
            ViewBag.image = _userManager.Users.First().ImageUrl;
            return View();
        }
    }
}
