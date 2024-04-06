using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ContactUsController : Controller
    {
        private readonly AppDbContext _db;
        public ContactUsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.ContacUs.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var contactUs = await _db.ContacUs.FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
                return NotFound();
            contactUs.Read = true;
            _db.SaveChanges();
            return View(contactUs);
        }
    }
}
