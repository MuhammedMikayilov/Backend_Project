using Backend_Project.DAL;
using Backend_Project.Models;
using Fiorello.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.SlideCount = _context.Sliders.Count();
            return View(_context.Sliders.ToList());
        }

        public IActionResult Create()
        {
            int count = _context.Sliders.Count();
            if (count >= 5)
            {
                return Content("You cannot add file than 5");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            #region MultiFile Upload
            if (slider.Photos == null)
            {
                return View();
            }
            int count = _context.Sliders.Count();
            if (count + slider.Photos.Length > 5)
            {
                ModelState.AddModelError("Photos", $"{5 - count} - image can select");
                return View();
            }
            foreach (IFormFile photo in slider.Photos)
            {
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} - not image type");
                    return View();
                }
                if (!photo.MaxSize(200))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} - Max image length must be less than 200kb");
                    return View();
                }
                Slider newSlider = new Slider();
                newSlider.Image = await photo.SaveImageAsync(_env.WebRootPath, "img");
                await _context.Sliders.AddAsync(newSlider);

            }
            await _context.SaveChangesAsync();
            #endregion

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            int count = _context.Sliders.Count();
            if (count == 1)
            {
                return Content("Get cehenem ol eee");
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = _context.Sliders.FirstOrDefault(c => c.Id == id);
            if (slider == null) return NotFound();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            //category.IsDeleted = true;
            //category.DeletedTime = DateTime.Now;
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
