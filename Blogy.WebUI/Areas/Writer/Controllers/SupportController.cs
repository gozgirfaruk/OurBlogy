using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class SupportController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageBoxDal _messageDal;

        public SupportController(UserManager<AppUser> userManager, IMessageBoxDal messageDal)
        {
            _userManager = userManager;
            _messageDal = messageDal;
        }

        [HttpGet]
        public IActionResult NewSupport()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> NewSupport(MessageBox p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string name = values.Name + " " + values.Surname;
            string mail = values.Email;
            p.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName = name;
            p.SenderMail = mail;
            p.ReceiverName = "Admin";
            p.ReceiverMail = "Admin@admin.com";

            _messageDal.Insert(p);

            return RedirectToAction("ReceiverMessage", "Eposta");
        }
    }
}
