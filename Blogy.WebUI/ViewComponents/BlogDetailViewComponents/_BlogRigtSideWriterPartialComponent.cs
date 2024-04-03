using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogRigtSideWriterPartialComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogRigtSideWriterPartialComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
