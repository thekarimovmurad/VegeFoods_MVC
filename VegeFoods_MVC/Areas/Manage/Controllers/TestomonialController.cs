using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;
using VegeFoods_MVC.Utils.Extentions;

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
        public async Task<IActionResult> Create([Bind("ProfileImage,ImageFile,FullName,Title,Message,Id")] Testomonial testomonial)
        {
            if (ModelState.IsValid)
            {
                if (testomonial.ImageFile.CheckFileType("image/"))
                {
                    if (testomonial.ImageFile.CheckFileSize(5000))
                    {
                        testomonial.ProfileImage = await testomonial.ImageFile.FileUpload(_env.WebRootPath, @"images");
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                        _db.Add(testomonial);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
            }
            return View(testomonial);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var testomonial = await _db.Testomonials.FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
                return NotFound();

            return View(testomonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileImage,ImageFile,FullName,Title,Message,Id")] Testomonial testomonial)
        {
            if (testomonial.ImageFile == null)
            {
                ModelState.Remove("ImageFile");
                ModelState.Remove("ProfileImage");
            }
            if (ModelState.IsValid)
            {
                if (testomonial.ImageFile != null)
                {
                    if (testomonial.ImageFile.CheckFileType("image/"))
                    {
                        if (testomonial.ImageFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"images\", testomonial.ProfileImage);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            testomonial.ProfileImage = await testomonial.ImageFile.FileUpload(_env.WebRootPath, @"images");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "File must be an image.");
                        return View();
                    }
                }
                _db.Update(testomonial);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testomonial);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var testomonial = await _db.Testomonials.FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
                return NotFound();

            return View(testomonial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
                return NotFound();
            var testomonial = await _db.Testomonials.FirstOrDefaultAsync(m => m.Id == id);
            if (testomonial == null)
                return NotFound();
            string filePath = Path.Combine(_env.WebRootPath, @"images\", testomonial.ProfileImage);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            _db.Testomonials.Remove(testomonial);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestomonialExists(int id)
        {
            return _db.Testomonials.Any(e => e.Id == id);
        }
    }
}
