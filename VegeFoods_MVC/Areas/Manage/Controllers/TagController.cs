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
    public class TagController : Controller
    {
        private readonly AppDbContext _db;

        public TagController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Tags.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var tag = await _db.Tags.FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
                return NotFound();
            return View(tag);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Add(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
                return NotFound();
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
                return NotFound();
            return View(tag);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
                return NotFound();
            var tag = await _db.Tags.FirstOrDefaultAsync(x => x.Id == id);
            if (tag == null)
                return NotFound();
            _db.Tags.Remove(tag);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
