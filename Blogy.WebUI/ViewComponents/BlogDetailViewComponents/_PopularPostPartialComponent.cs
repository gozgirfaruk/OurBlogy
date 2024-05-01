using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _PopularPostPartialComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _PopularPostPartialComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetyById(id).AppUserID;
            using var c = new BlogyContext();
            var popular = c.Articles.Where(x=>x.AppUserID==values).ToList();
            ViewBag.i = id;
            return View(popular);
        }
    }
}
