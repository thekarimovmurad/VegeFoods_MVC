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
    public class TestomonialController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public TestomonialController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Testomonials.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var testomonial = await _db.Testomonials.FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
                return NotFound();

            return View(testomonial);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileImage,FullName,Title,Message,Id")] Testomonial testomonial)
        {
            if (ModelState.IsValid)
            {
                _db.Add(testomonial);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testomonial);
        }

        // GET: Manage/Testomonial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var testomonial = await _db.Testomonials.FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
                return NotFound();

            return View(testomonial);
        }

        // POST: Manage/Testomonial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileImage,FullName,Title,Message,Id")] Testomonial testomonial)
        {
            if (id != testomonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(testomonial);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestomonialExists(testomonial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testomonial);
        }

        // GET: Manage/Testomonial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testomonial = await _db.Testomonials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
            {
                return NotFound();
            }

            return View(testomonial);
        }

        // POST: Manage/Testomonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testomonial = await _db.Testomonials.FindAsync(id);
            if (testomonial != null)
            {
                _db.Testomonials.Remove(testomonial);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestomonialExists(int id)
        {
            return _db.Testomonials.Any(e => e.Id == id);
        }
    }
}
