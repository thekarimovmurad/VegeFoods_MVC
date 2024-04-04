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

namespace VegeFoods_MVC.Areas.Admin.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Sliders.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _db.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BackgroundImage,ImageFile,Title,Subtitle,Id")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.ImageFile.CheckFileType("image/"))
                {
                    if (slider.ImageFile.CheckFileSize(5000))
                    {
                        slider.BackgroundImage = await slider.ImageFile.FileUpload(_env.WebRootPath, @"images");
                        _db.Add(slider);
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
            return View(slider);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _db.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _db.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (slider == null)
                return NotFound();
            string filePath = Path.Combine(_env.WebRootPath, @"images\", slider.BackgroundImage);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _db.Sliders.FirstOrDefaultAsync(x => x.Id == id);
            if (slider == null)
                return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BackgroundImage,ImageFile,Title,Subtitle,Id")] Slider slider)
        {
            if (slider.ImageFile == null)
            {
                ModelState.Remove("ImageFile");
                ModelState.Remove("BackgroundImage");
            }
            if (ModelState.IsValid)
            {
                if (slider.ImageFile != null)
                {
                    if (slider.ImageFile.CheckFileType("image/"))
                    {
                        if (slider.ImageFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"images\", slider.BackgroundImage);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            slider.BackgroundImage = await slider.ImageFile.FileUpload(_env.WebRootPath, @"images");
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
                _db.Update(slider);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }
    }
}
