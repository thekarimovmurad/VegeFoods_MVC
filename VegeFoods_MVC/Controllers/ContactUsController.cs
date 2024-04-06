using Microsoft.AspNetCore.Mvc;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.Controllers
{
    public class ContactUsController : Controller
    {
		private readonly AppDbContext _db;
        public ContactUsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("FullName,Email,Subject,Read,Message,Time,Id")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.Time = DateTime.Now;
                _db.Add(contactUs);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(contactUs);
        }
    }
}
