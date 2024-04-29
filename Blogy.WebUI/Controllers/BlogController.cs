using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _article;
        private readonly BlogyContext _blogyContext;

		public BlogController(IArticleService article, BlogyContext blogyContext)
		{
			_article = article;
			_blogyContext = blogyContext;
		}

		public IActionResult BlogList()
        {
            return View();
        }

        public IActionResult AllBlogList(string p)
        {
            var values = _article.GetArticleWithCategory();
         
            return View(values);
        }

        public PartialViewResult AllBlogTagPartial()
        {
            var values = _article.GetArticleWithCategory();
            return PartialView(values);
        }

        public IActionResult BlogDetail(int id)
        {
            
           var values = _article.TGetyById(id);
            ViewBag.i = id;
            return View(values);
        }


    }
}
