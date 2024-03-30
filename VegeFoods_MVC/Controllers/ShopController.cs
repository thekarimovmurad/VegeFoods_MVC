using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _db;
        public ShopController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Sliders.Take(12).ToListAsync());
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return RedirectToAction("Index", "home");
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) return RedirectToAction("Index", "home");
            return Ok("okay");
        }
    }
}
