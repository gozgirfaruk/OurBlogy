using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class EpostaController : Controller
    {
        MessageBoxMenager _messageDal = new MessageBoxMenager(new EfMessageBoxDal());
        private readonly UserManager<AppUser> _userManager;

        public EpostaController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageDal.GetListSender(p);
            return View(messageList);
        }
        public IActionResult SenderMessageDetail(int id)
        {
            var values = _messageDal.TGetyById(id);
            return View(values);
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageDal.GetListReceiver(p);
            return View(messageList);
        }

        public IActionResult ReceiverMessageDetail(int id)
        {
            var values = _messageDal.TGetyById(id);
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            _messageDal.TDelete(id);
            return RedirectToAction("ReceiverMessage");
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(MessageBox p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + "" + values.Surname;
            p.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName = name;
            p.SenderMail = mail;
            BlogyContext c = new BlogyContext();
            var username = c.Users.Where(x=>x.Email==p.ReceiverMail).Select(y=>y.Name + "" + y.Surname).FirstOrDefault();
            p.ReceiverName = username;
            _messageDal.TInsert(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
