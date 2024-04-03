using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.WrtierListViewComponents
{
    public class _WriterListComponent : ViewComponent
    {
       private readonly IWriterService _writerService;

        public _WriterListComponent(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _writerService.TGetAll();
            return View(values);
        }
    }
}
