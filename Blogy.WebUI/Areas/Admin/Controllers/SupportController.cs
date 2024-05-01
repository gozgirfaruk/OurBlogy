using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class SupportController : Controller
    {
        private readonly MessageBoxMenager _boxMenager = new MessageBoxMenager(new EfMessageBoxDal());

        public IActionResult Inbox()
        {
            var values = _boxMenager.GetListReceiver("Admin@admin.com");
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("Inbox");
        }
    }
}
