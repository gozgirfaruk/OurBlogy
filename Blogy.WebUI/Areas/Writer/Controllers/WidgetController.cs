using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area ("Writer")]
    public class WidgetController : Controller
    {
        private readonly BlogyContext _blogyContext;
        private readonly UserManager<AppUser> _userManager;

        public WidgetController(BlogyContext blogyContext, UserManager<AppUser> userManager)
        {
            _blogyContext = blogyContext;
            _userManager = userManager;
        }

        public async Task<IActionResult>  Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.one = _blogyContext.Articles.Where(x=>x.AppUserID==user.Id).Count();
            ViewBag.two = _blogyContext.Contacts.Count();
            ViewBag.three = _blogyContext.Tags.Select(x => x.TagTitle).FirstOrDefault().ToString();
            ViewBag.four = _blogyContext.MessageBoxes.Where(x => x.SenderMail == user.Email).Count();
            ViewBag.five = _blogyContext.MessageBoxes.Where(x=>x.ReceiverMail == user.Email).Count();
            ViewBag.eight = _blogyContext.Articles.Count();
            ViewBag.nine = _blogyContext.Categories.Count();
            ViewBag.zero = _blogyContext.Articles.OrderByDescending(x => x.CreatedDate).Select(y => y.Title).FirstOrDefault();
            ViewBag.eleven = _blogyContext.Users.Count();
            ViewBag.ten = _blogyContext.Articles.Select(x => x.Title).FirstOrDefault();
            ViewBag.twelve = _blogyContext.Notifications.Count();
            return View();
        }
    }
}
