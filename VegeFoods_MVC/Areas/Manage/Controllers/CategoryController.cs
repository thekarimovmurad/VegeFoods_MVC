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
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Categorys.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await _db.Categorys.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ImageFile,CategoryImage,Id")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ImageFile.CheckFileType("image/"))
                {
                    if (category.ImageFile.CheckFileSize(5000))
                    {
                        category.CategoryImage = await category.ImageFile.FileUpload(_env.WebRootPath, @"images");
                        _db.Add(category);
                        await _db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
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
            return View(category);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await _db.Categorys.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ImageFile,CategoryImage,Id")] Category category)
        {
            if (category.ImageFile == null)
            {
                ModelState.Remove("ImageFile");
                ModelState.Remove("CategoryImage");
            }

            if (ModelState.IsValid)
            {
                if (category.ImageFile != null)
                {
                    if (category.ImageFile.CheckFileType("image/"))
                    {
                        if (category.ImageFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"images\", category.CategoryImage);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            category.CategoryImage = await category.ImageFile.FileUpload(_env.WebRootPath, @"images");
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
                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await _db.Categorys.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
                return NotFound();
            var category = await _db.Categorys.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
                return NotFound();

            string filePath = Path.Combine(_env.WebRootPath, @"images\", category.CategoryImage);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            _db.Categorys.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}