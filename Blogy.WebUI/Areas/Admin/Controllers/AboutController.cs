using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AboutController : Controller
    {
        private readonly BlogyContext _context;

        public AboutController(BlogyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values =_context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Update(int id=1)
        {
            var values = _context.Abouts.Find(id);
            return View(values);
        }

        [Route("Admin/About/")]
        [HttpPost]
        public IActionResult Update(Blogy.EntityLayer.Concrete.About p)
        {
            var values = _context.Abouts.Update(p);
            return RedirectToAction("Index","About");
        }
    }
}
