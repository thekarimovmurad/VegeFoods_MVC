using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.Areas.Manage.ViewModels;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.ViewModels;

namespace VegeFoods_MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel()
            {
                partnersCount = await _db.Partners.CountAsync(),
                slidersCount= await _db.Sliders.CountAsync(),
            };
            return View(dvm);
        }
    }
}
