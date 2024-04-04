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
    public class OurServiceController : Controller
    {
		private readonly AppDbContext _db;
		public OurServiceController(AppDbContext db)
		{
			_db = db;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _db.OurServices.ToListAsync());
		}
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
				return NotFound();
			var ourService = await _db.OurServices.FirstOrDefaultAsync(x => x.Id == id);
			if (ourService == null)
				return NotFound();
			return View(ourService);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SVGImage,Title,Subtitle,Id")] OurService ourService)
		{
			if (ModelState.IsValid)
			{
				_db.Add(ourService);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(ourService);
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();
			var ourService = await _db.OurServices.FirstOrDefaultAsync(x => x.Id == id);
			if (ourService == null)
				return NotFound();
			return View(ourService);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("SVGImage,Title,Subtitle,Id")] OurService ourService)
		{
			if (ModelState.IsValid)
			{
				_db.Update(ourService);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(ourService);
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();
			var ourService = await _db.OurServices.FirstOrDefaultAsync(x => x.Id == id);
			if (ourService == null)
				return NotFound();
			return View(ourService);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (id == null)
				return NotFound();
			var ourService = await _db.OurServices.FirstOrDefaultAsync(x => x.Id == id);
			if (ourService == null)
				return NotFound();
			_db.OurServices.Remove(ourService);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
