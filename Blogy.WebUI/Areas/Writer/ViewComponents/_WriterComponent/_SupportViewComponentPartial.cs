using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents._WriterComponent
{
    public class _SupportViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new BlogyContext();
            var messageList = c.MessageBoxes.Where(x => x.SenderMail == "Admin@admin.com").ToList();
            ViewBag.a = c.MessageBoxes.Where(x => x.SenderMail == "Admin@admin.com").Count();
            return View(messageList);
        }
    }
}
