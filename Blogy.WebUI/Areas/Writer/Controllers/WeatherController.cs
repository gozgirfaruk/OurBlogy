using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WeatherController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WeatherController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public  async Task<IActionResult> SevenDays()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name + "" + values.Surname;

            string api = "3aa77bd7f409dbc69745c3246d68057c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=gaziantep&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.today = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.wind = document.Descendants("speed").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
