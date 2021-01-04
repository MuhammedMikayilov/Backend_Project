using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Extentions;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TestimonialsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault();
            return View(testimonial);
        }

        public IActionResult Update(int? id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(a => a.Id == id);
            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Testimonial testimonial)
        {
            Testimonial testimonialOld = _context.Testimonials.FirstOrDefault(a => a.Id == id);
            if (id == null) return RedirectToAction("ErrorPage", "Home");
            if (testimonial == null) return RedirectToAction("ErrorPage", "Home");

            if (testimonial.Photo != null)
            {
                if (!testimonial.Photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{testimonial.Photo.FileName} - not image type");
                    return View(testimonialOld);
                }

                string folder = Path.Combine("img", "testimonial");
                string fileName = await testimonial.Photo.SaveImageAsync(_env.WebRootPath, folder);
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, testimonialOld.Image);
                testimonialOld.Image = fileName;
            }

            testimonialOld.Fullname = testimonial.Fullname;
            testimonialOld.Description = testimonial.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
