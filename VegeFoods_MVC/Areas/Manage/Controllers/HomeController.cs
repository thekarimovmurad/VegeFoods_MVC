using Microsoft.AspNetCore.Mvc;

namespace VegeFoods_MVC.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
