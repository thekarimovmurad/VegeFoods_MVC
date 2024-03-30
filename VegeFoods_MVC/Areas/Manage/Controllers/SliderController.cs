using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VegeFoods_MVC.DAL;
using VegeFoods_MVC.Models;

namespace VegeFoods_MVC.Areas.Admin.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _db;

        public SliderController(AppDbContext db)
        {
            _db = db;
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

		private bool SliderExists(int? id)
		{
			return _db.Sliders.Any(e => e.Id == id);
		}
		//// GET: Admin/Slider/Create
		//public IActionResult Create()
  //      {
  //          return View();
  //      }

        //// POST: Admin/Slider/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("BackgroundImage,Title,Subtitle,Id")] Slider slider)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(slider);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(slider);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Subtitle,ImageFile,Image")] Slider slider)
        //{
        //    if (ModelState.IsValid)
        //    {   
        //        if (slider.ImageFile.CheckFileType("image/"))
        //        {
        //            if (slider.ImageFile.CheckFileSize(5000))
        //            {
        //                slider.Image = await slider.ImageFile.FileUpload(_env.WebRootPath, @"image");
        //                _context.Add(slider);
        //                await _context.SaveChangesAsync();
        //                return RedirectToAction("www.google.com");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
        //                return View();
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ImageFile", "File must be an image.");
        //            return View();
        //        }

        //    }
        //    //var errors = ModelState.Select(x => x.Value.Errors)
        //    //		   .Where(y => y.Count > 0)
        //    //		   .ToList();
        //    //Console.WriteLine(errors);	
        //    //foreach (var modelStateEntry in ModelState.Values)
        //    //{
        //    //	foreach (var error in modelStateEntry.Errors)
        //    //	{
        //    //		Console.WriteLine(error.ErrorMessage);
        //    //		Console.WriteLine(modelStateEntry);
        //    //      Console.WriteLine("sdakljdadjb daksbljbj fnadshjmnk");
        //    //    }
        //    //}

        //    foreach (var key in ModelState.Keys)
        //    {
        //        var errors = ModelState[key].Errors;
        //        foreach (var error in errors)
        //        {
        //            Console.WriteLine($"{key}: {error.ErrorMessage}");
        //        }
        //    }


        //    // Return the view with the model
        //    return View(slider);
        //    //if (ModelState.IsValid)
        //    //{
        //    //	if (!slider.ImageFile.IsImage())
        //    //	{
        //    //		ModelState.AddModelError("ImageFile", "File must be an image.");
        //    //		return View();
        //    //	}
        //    //	if (!student.ImageFile.IsValidSize(5000))
        //    //	{
        //    //		ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
        //    //		return View();
        //    //	}
        //    //	student.Image = await student.ImageFile.Upload(_env.WebRootPath, @"assets\img\Upload\Student");
        //    //	_context.Add(student);
        //    //	await _context.SaveChangesAsync();
        //    //	return RedirectToAction(nameof(Index));
        //    //}
        //    //ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", student.GroupId);
        //    //return View(student);

        //}


        //// GET: Admin/Slider/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var slider = await _context.Sliders.FindAsync(id);
        //    if (slider == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(slider);
        //}

        //// POST: Admin/Slider/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BackgroundImage,Title,Subtitle,Id")] Slider slider)
        //{
        //    if (id != slider.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(slider);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SliderExists(slider.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(slider);
        //}

        //// GET: Admin/Slider/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var slider = await _context.Sliders
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (slider == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(slider);
        //}

        //// POST: Admin/Slider/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var slider = await _context.Sliders.FindAsync(id);
        //    if (slider != null)
        //    {
        //        _context.Sliders.Remove(slider);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
