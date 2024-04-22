using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class AboutUsController : Controller
    {
        BlogyContext context = new BlogyContext();
        public IActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
    }
}
