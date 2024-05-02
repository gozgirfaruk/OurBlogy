using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly BlogyContext _context;

        public WriterController(BlogyContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
