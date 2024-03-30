using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;
using VegeFoods_MVC.ViewModels;

namespace VegeFoods_MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            AboutViewModel hvm = new AboutViewModel()
            {
                partnerCounts = await _db.PartnerCounts.FirstOrDefaultAsync(),
                ourServices = await _db.OurServices.ToListAsync(),
                testomonials = await _db.Testomonials.ToListAsync(),
                aboutUs =await _db.AboutUs.FirstOrDefaultAsync(),
            };
            return View(hvm);
        }
    }
}
