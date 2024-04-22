using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents
{
    public class _BlogListFooterComponentPartial : ViewComponent
    {
        BlogyContext context = new BlogyContext();
        public IViewComponentResult Invoke()
        {
            var values =context.Socials.ToList();   
            return View(values);
        }

    }
}
