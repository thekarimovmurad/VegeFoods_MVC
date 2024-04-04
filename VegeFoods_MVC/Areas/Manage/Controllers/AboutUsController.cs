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
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public AboutUsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var aboutUs = await _db.AboutUs.FirstOrDefaultAsync();
            return View(aboutUs);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var aboutUs = await _db.AboutUs.FindAsync(id);
            if (aboutUs == null)
                return NotFound();
            return View(aboutUs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Subtitle,VideoFile,Video,ImageFile,Image,Id")] AboutUs aboutUs)
        {
            if (id == null)
                return NotFound();
            if (aboutUs.ImageFile == null)
            {
                ModelState.Remove("ImageFile");
                ModelState.Remove("Image");
            }
            if (aboutUs.VideoFile == null)
            {
                ModelState.Remove("VideoFile");
                ModelState.Remove("Video");
            }
            if (ModelState.IsValid)
            {
                if (aboutUs.ImageFile != null)
                {
                    if (aboutUs.ImageFile.CheckFileType("image/"))
                    {
                        if (aboutUs.ImageFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"images\", aboutUs.Image);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            aboutUs.Image = await aboutUs.ImageFile.FileUpload(_env.WebRootPath, @"images");
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
                if (aboutUs.VideoFile != null)
                {
                    if (aboutUs.VideoFile.CheckFileType("video/"))
                    {
                        if (aboutUs.VideoFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"videos\", aboutUs.Video);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            aboutUs.Video = await aboutUs.VideoFile.FileUpload(_env.WebRootPath, @"videos");
                        }
                        else
                        {
                            ModelState.AddModelError("VideoFile", "Max file size is 5000 kbs.");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("VideoFile", "File must be an video mp4.");
                        return View();
                    }
                }
                _db.Update(aboutUs);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUs);
        }
    }
}
