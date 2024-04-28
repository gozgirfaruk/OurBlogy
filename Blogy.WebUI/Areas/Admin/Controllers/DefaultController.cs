using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
    private readonly IWriterService _writerService;

        public DefaultController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var values = _writerService.TGetAll();
            return View(values);
        }

        public IActionResult StatusChanger(int id)
        {
            var values = _writerService.TGetyById(id);
            if(values.Status==true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }
            return RedirectToAction("WriterList");
        }
    }
}
