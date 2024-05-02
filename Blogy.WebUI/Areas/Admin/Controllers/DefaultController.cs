using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
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

        [HttpPost]
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
            return RedirectToAction("WriterList","Default");
        }

        public IActionResult Delete(int id)
        {
            _writerService.TDelete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _writerService.TGetyById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Update(Blogy.EntityLayer.Concrete.Writer writer)
        {
            _writerService.TUpdate(writer);
            return RedirectToAction("Index");
        }

    }
}
