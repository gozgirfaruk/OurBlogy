using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactViewComponents
{
	public class _AdressComponentPartial : ViewComponent
	{
		BlogyContext context = new BlogyContext();
		public IViewComponentResult Invoke()
		{
			var values = context.Addresses.FirstOrDefault();
			return View(values);
		}
	}
}
