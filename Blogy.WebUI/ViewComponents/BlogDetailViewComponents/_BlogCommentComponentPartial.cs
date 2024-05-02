using Blogy.BusinessLayer.Abstract;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogCommentComponentPartial : ViewComponent
    {
        private readonly ICommentService commentService;

        public _BlogCommentComponentPartial(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = new CommnetPostViewModel()
            {
                ArticleID = id
            };
            return View(values);
        }
    }
}
