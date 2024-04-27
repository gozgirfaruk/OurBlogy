using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _AllBlogListSideBarPartialComponent : ViewComponent
    {
        private readonly BlogyContext _blogyContext;

		public _AllBlogListSideBarPartialComponent(BlogyContext blogyContext)
		{
			_blogyContext = blogyContext;
		}

		public IViewComponentResult Invoke()
        {
            var values = _blogyContext.Articles.Take(3).ToList();
            return View(values);
        }
    }
}
