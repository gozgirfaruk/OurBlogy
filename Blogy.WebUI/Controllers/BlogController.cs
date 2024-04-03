using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly IArticleService _article;

        public BlogController(IArticleService article)
        {
            _article = article;
        }



        public IActionResult BlogList()
        {
            return View();
        }

        public IActionResult AllBlogList()
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
            return View(values);
        }


    }
}
