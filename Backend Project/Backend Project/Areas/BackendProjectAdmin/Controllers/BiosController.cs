using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Extentions;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
    public class BiosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public BiosController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            Bios bios = _context.Bios.FirstOrDefault();
            return View(bios);
        }

        public IActionResult Update(int? id)
        {
            Bios bio = _context.Bios.FirstOrDefault(bio => bio.Id == id);

            return View(bio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Bios bios)
        {
            Bios oldBio = _context.Bios.FirstOrDefault(bio => bio.Id == id);
            if (bios.PhotoHeader != null)
            {
                if (!bios.PhotoHeader.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{bios.PhotoHeader.FileName} - not image type");
                    return View(oldBio);
                }

                string folder = Path.Combine("img", "bios");
                string fileName = await bios.PhotoHeader.SaveImageAsync(_env.WebRootPath, folder);
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, oldBio.HeaderLogo);
                oldBio.HeaderLogo = fileName;
            }
            if (bios.Photo != null)
            {
                if (!bios.Photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{bios.Photo.FileName} - not image type");
                    return View(oldBio);
                }

                string folder = Path.Combine("img", "bios");
                string fileName = await bios.Photo.SaveImageAsync(_env.WebRootPath, folder);
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, oldBio.HeaderLogo);
                oldBio.Logo = fileName;
            }

            oldBio.Address = bios.Address;
            oldBio.Place = bios.Place;
            oldBio.Number = bios.Number;
            oldBio.Phono1 = bios.Phono1;
            oldBio.Phone2 = bios.Phone2;
            oldBio.Description = bios.Description;

            oldBio.Facebook = bios.Facebook;
            oldBio.Pinterest = bios.Pinterest;
            oldBio.Twitter = bios.Twitter;
            oldBio.Vimeo = bios.Vimeo;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
