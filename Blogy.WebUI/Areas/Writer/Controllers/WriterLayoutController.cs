using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriterLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _context;

        public WriterLayoutController(UserManager<AppUser> userManager, BlogyContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.name = _userManager.Users.First().Name;
            ViewBag.surname = _userManager.Users.First().Surname;
            ViewBag.image = _userManager.Users.First().ImageUrl;

            var number = _userManager.Users.First().Id;
            ViewBag.values = _context.Articles.Where(x => x.AppUserID == number).Count();
            return View();
        }
    }
}
