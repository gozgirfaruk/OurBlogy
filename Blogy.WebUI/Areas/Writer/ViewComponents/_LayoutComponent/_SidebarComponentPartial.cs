using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents._LayoutComponent
{
    public class _SidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _context;
        public _SidebarComponentPartial(UserManager<AppUser> userManager, BlogyContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.name = _userManager.Users.First().Name;
            ViewBag.surname = _userManager.Users.First().Surname;
            ViewBag.image = _userManager.Users.First().ImageUrl;

            var number = _userManager.Users.First().Id;
            ViewBag.values = _context.Articles.Where(x => x.AppUserID == number).Count();
            
            //ViewBag.number = _userManager.FindByNameAsync(User.Identity.Name);
            //var values = _context.Articles.Where(x=>x.AppUserID==number).Count();
           
            
            return View();
        }
    }
}
