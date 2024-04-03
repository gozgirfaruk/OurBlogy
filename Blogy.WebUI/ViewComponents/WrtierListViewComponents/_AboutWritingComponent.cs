using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.WrtierListViewComponents
{
	public class _AboutWritingComponent : ViewComponent
	{
		IAboutService _aboutService;

		public _AboutWritingComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _aboutService.GetAll();
			return View(values);
		}
	}
}
