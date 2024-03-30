using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;
using VegeFoods_MVC.ViewModels;

namespace VegeFoods_MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            BlogViewModel bvm = new BlogViewModel()
            {
                blogs= await _db.Blogs.ToListAsync(),
                tags= await _db.Tags.ToListAsync(),
            };
            return View(bvm);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return RedirectToAction("Index", "Blog");
            Blog blog = await _db.Blogs.FirstOrDefaultAsync(x => x.Id == Id);
            if (blog == null) return RedirectToAction("Index", "Blog");
            return Ok("okay");
        }
    }
}
