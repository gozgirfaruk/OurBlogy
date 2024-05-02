using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class GoogleChartController : Controller
    {
        private readonly BlogyContext _blogContext;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public GoogleChartController(BlogyContext blogContext, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _blogContext = blogContext;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.one = _blogContext.Articles.Where(x => x.AppUserID == user.Id).Count();
            ViewBag.two = _blogContext.Contacts.Count();
            ViewBag.three = _blogContext.Tags.Select(x => x.TagTitle).FirstOrDefault().ToString();
            ViewBag.four = _blogContext.MessageBoxes.Where(x => x.SenderMail == user.Email).Count();
            ViewBag.five = _blogContext.MessageBoxes.Where(x => x.ReceiverMail == user.Email).Count();
            ViewBag.eight = _blogContext.Articles.Count();
            ViewBag.nine = _blogContext.Categories.Count();
            ViewBag.zero = _blogContext.Articles.OrderByDescending(x => x.CreatedDate).Select(y => y.Title).FirstOrDefault();
            ViewBag.eleven = _blogContext.Users.Count();
            ViewBag.ten = _blogContext.Articles.Select(x => x.Title).FirstOrDefault();
            ViewBag.twelve = _blogContext.Notifications.Count();
            return View();
        }

        public IActionResult Chart()
        {
            var values = _blogContext.Articles.GroupBy(x => x.CategoryID).Select(y => new ChartViewModel
            {
                categoryname = _blogContext.Categories.Where(x => x.CategoryID == y.Key).Select(c => c.CategoryName).FirstOrDefault(),
                count = y.Count()
            }).ToList();

            return Json(new { jsonlist = values });

        }

    }
}
