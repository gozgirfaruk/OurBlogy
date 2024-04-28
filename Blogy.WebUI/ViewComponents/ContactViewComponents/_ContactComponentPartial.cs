using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.ContactViewComponents
{
	public class _ContactComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke(Contact contact)
		{
			return View();
		}
	}
}
