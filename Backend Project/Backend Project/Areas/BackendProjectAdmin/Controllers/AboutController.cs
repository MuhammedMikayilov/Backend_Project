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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            About about = _context.Abouts.FirstOrDefault();
            return View(about);
        }

        public IActionResult Update(int? id)
        {
            About about = _context.Abouts.FirstOrDefault(a => a.Id == id);
            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, About about)
        {
            About aboutOld = _context.Abouts.FirstOrDefault(a => a.Id == id);
            if (id == null) return RedirectToAction("ErrorPage", "Home");
            if (about == null) return RedirectToAction("ErrorPage", "Home");

            if (about.Photo != null)
            {
                if (!about.Photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{about.Photo.FileName} - not image type");
                    return View(aboutOld);
                }

                string folder = Path.Combine("img", "about");
                string fileName = await about.Photo.SaveImageAsync(_env.WebRootPath, folder);
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, aboutOld.Image);
                aboutOld.Image = fileName;
            }

            aboutOld.Title = about.Title;
            aboutOld.Description = about.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
