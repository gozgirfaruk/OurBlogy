using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
