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
    public class PartnerController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PartnerController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Partners.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<IActionResult> Create([Bind("PartnerLogo,ImageFile,Id")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                if (partner.ImageFile.CheckFileType("image/"))
                {
                    if (partner.ImageFile.CheckFileSize(5000))
                    {
                        partner.PartnerLogo = await partner.ImageFile.FileUpload(_env.WebRootPath, @"images");
                        _db.Add(partner);
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
            return View(partner);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();
            return View(partner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
                return NotFound();
            var partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();
            string filePath = Path.Combine(_env.WebRootPath, @"images\", partner.PartnerLogo);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            _db.Partners.Remove(partner);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var partner = await _db.Partners.FirstOrDefaultAsync(x => x.Id == id);
            if (partner == null)
                return NotFound();
            return View(partner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartnerLogo,ImageFile,Id")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                if (partner.ImageFile != null)
                {
                    if (partner.ImageFile.CheckFileType("image/"))
                    {
                        if (partner.ImageFile.CheckFileSize(5000))
                        {
                            string filePath = Path.Combine(_env.WebRootPath, @"images\", partner.PartnerLogo);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                            partner.PartnerLogo = await partner.ImageFile.FileUpload(_env.WebRootPath, @"images");
                            _db.Update(partner);
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
            }
            return View(partner);
        }
    }
}
