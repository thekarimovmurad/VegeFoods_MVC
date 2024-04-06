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
    public class PartnerCountController : Controller
    {
		private readonly AppDbContext _db;
		private readonly IWebHostEnvironment _env;
		public PartnerCountController(AppDbContext db, IWebHostEnvironment env)
		{
			_db = db;
			_env = env;
		}
		public async Task<IActionResult> Index()
        {
            return View(await _db.PartnerCounts.FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var partnerCount = await _db.PartnerCounts.FindAsync(id);
            if (partnerCount == null)
                return NotFound();
            return View(partnerCount);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HappyUser,Awards,Branch,Partner,BackgroundImage,ImageFile,Id")] PartnerCount partnerCount)
        {
			if (id == null)
				return NotFound();
			if (partnerCount.ImageFile == null)
			{
				ModelState.Remove("ImageFile");
				ModelState.Remove("BackgroundImage");
			}
			if (ModelState.IsValid)
			{
				if (partnerCount.ImageFile != null)
				{
					if (partnerCount.ImageFile.CheckFileType("image/"))
					{
						if (partnerCount.ImageFile.CheckFileSize(5000))
						{
							string filePath = Path.Combine(_env.WebRootPath, @"images\", partnerCount.BackgroundImage);
							if (System.IO.File.Exists(filePath))
								System.IO.File.Delete(filePath);
							partnerCount.BackgroundImage = await partnerCount.ImageFile.FileUpload(_env.WebRootPath, @"images");
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
				_db.Update(partnerCount);
				await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(partnerCount);
        }
        private bool PartnerCountExists(int id)
        {
            return _db.PartnerCounts.Any(e => e.Id == id);
        }
    }
}
