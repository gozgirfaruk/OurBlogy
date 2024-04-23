using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents
{
    public class _SignUpSocialComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var db = new BlogyContext();
            var values = db.Socials.ToList();   
            return View(values);
        }
    }
}
