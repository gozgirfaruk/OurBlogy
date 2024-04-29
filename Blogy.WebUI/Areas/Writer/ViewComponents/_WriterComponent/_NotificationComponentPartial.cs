using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents._WriterComponent
{
	public class _NotificationComponentPartial : ViewComponent
	{
		private readonly INotificationService _notificationService;

        public _NotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
		{
			var values = _notificationService.TGetAll();
			ViewBag.a = _notificationService.TGetAll().Count;
			return View(values);
		}
	}
}
