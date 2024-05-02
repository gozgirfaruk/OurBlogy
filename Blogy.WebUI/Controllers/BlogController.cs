using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _article;
        private readonly BlogyContext _blogyContext;
        private readonly ICommentService _commentService;

		public BlogController(IArticleService article, BlogyContext blogyContext)
		{
			_article = article;
			_blogyContext = blogyContext;
		}

		public IActionResult BlogList()
        {
            return View();
        }

        public IActionResult AllBlogList(string p)
        {
            var values = _article.GetArticleWithCategory();
         
            return View(values);
        }

        public PartialViewResult AllBlogTagPartial()
        {
            var values = _article.GetArticleWithCategory();
            return PartialView(values);
        }
        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            return View();
        }
        [HttpPost]
        public IActionResult BlogDetail(int id ,Comment comment)
        {
            comment.ArticleID= id;
            comment.CommentDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Status = true;
            _commentService.TInsert(comment);
            return RedirectToAction("BlogList");
        }

        [HttpPost]
        public IActionResult InsertComment(CommnetPostViewModel p)
        {
            Comment com = new Comment()
            {
                ArticleID = p.ArticleID,
                NameSurname = p.NameSurname,
                Email = p.Mail,
                CommentDate = DateTime.Now,
                Subject = p.Subject
            };
            _commentService.TInsert(com);
           
            return RedirectToAction("BlogList","Blog");
        }


    }
}
