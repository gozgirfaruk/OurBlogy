using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class _BlogDetailCommentPartialComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _BlogDetailCommentPartialComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {

            var values = _commentService.TGetCommentByArticleID(id).ToList();
            
            return View(values);
        }

    }
}
