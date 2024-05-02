using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private readonly BlogyContext _contex;

        public AddressController(BlogyContext contex)
        {
            _contex = contex;
        }

        public IActionResult Index()
        {
            var values = _contex.Addresses.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Update(int id=1)
        {
            var values = _contex.Addresses.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(Address address)
        {
            _contex.Addresses.Update(address);
            return RedirectToAction("Index","Address", new {Areas="Admin"});
        }
    }
}
