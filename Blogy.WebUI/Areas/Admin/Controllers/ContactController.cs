using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly MessageBoxMenager _messageDal = new MessageBoxMenager(new EfMessageBoxDal());

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(MessageBox p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName = "Admin";
            p.SenderMail = "Admin@admin.com";
            BlogyContext c = new BlogyContext();
            var username = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + "" + y.Surname).FirstOrDefault();
            p.ReceiverName = username;
            _messageDal.TInsert(p);
            return RedirectToAction("Inbox" , "Support");
        }

    }
}