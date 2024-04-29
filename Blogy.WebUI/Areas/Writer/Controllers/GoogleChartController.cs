using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class GoogleChartController : Controller
    {
        private readonly BlogyContext _blogContext;

        public GoogleChartController(BlogyContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            ViewBag.a = _blogContext.Articles.Where(x => x.CategoryID == 1).Count();
            ViewBag.b = _blogContext.Articles.Where(x => x.CategoryID == 2).Count();
            ViewBag.c = _blogContext.Articles.Where(x => x.CategoryID == 6).Count();
            ViewBag.d = _blogContext.Articles.Where(x => x.CategoryID == 10).Count();
            ViewBag.e = _blogContext.Articles.Where(x => x.CategoryID == 11).Count();
            return View();
        }

    }
}
