using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogExplanationPartialComponent : ViewComponent
    {
        private readonly IArticleService _article;

        public _BlogExplanationPartialComponent(IArticleService article)
        {
            _article = article;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _article.TGetyById(id);
            return View(values);
        }
    }
}
