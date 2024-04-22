using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents
{
	public class _FooterRecentEntryComponentPartial : ViewComponent
	{
		ArticleMenager _articleMenager = new ArticleMenager(new EfArticleDal());
		public IViewComponentResult Invoke()
		{
			var values = _articleMenager.TGetAll().OrderByDescending(x=>x.ArticleID).Take(3).ToList();
			return View(values);
		}
	}
}
