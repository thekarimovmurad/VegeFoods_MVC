using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.ViewModels;
using System;
using System.Diagnostics;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                sliders = await _db.Sliders.ToListAsync(),
                ourServices= await _db.OurServices.ToListAsync(),
                categories= await _db.Categorys.ToListAsync(),
                products= await _db.Products.ToListAsync(),
                testomonials = await _db.Testomonials.ToListAsync(),
                partners = await _db.Partners.Take(5).ToListAsync(),
            };
            return View(hvm);
        }
    }
}
