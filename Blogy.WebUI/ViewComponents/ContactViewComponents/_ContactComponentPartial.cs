using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactViewComponents
{
	public class _ContactComponentPartial : ViewComponent
	{
		BlogyContext context = new BlogyContext();
		public IViewComponentResult Invoke()
		{ 
			return View();
		}
	}
}
