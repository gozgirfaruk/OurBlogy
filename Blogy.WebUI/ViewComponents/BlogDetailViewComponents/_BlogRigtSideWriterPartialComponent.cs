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

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetWriterInfoByArticleWriter(id);
            return View(values);
        }
    }
}
