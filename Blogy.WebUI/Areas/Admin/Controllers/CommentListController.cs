using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentListController : Controller
    {
        private readonly BlogyContext _context;

        public CommentListController(BlogyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Comments.Include(x=>x.Article).ToList();
            return View(values);
        }


        public IActionResult Delete(int id)
        {
            var values = _context.Comments.Find(id);
            _context.Comments.Remove(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.Comments.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Update(Comment comment)
        {
            _context.Comments.Update(comment);
            return RedirectToAction("Index");
        }
    }
}
