using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailByCoverInfoPartialComponent :ViewComponent
    {
        private readonly IArticleService _articleService;

		public _BlogDetailByCoverInfoPartialComponent(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetyById(id);
            return View(values);
        }
    }
}
