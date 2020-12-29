using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Helpers;
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
    public class TitleController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TitleController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Titles.ToList());
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Titles title = _context.Titles.Where(t => t.IsDelete == false).FirstOrDefault(t => t.Id == id);
            if (title == null) return NotFound();
            await _context.SaveChangesAsync();
            return View(title);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Titles titles, int? id)
        {
            Titles t = await _context.Titles.FindAsync(id);

            if (!ModelState.IsValid) return RedirectToAction("ErrorPage","Home");

            Titles isExist = _context.Titles.Where(t => t.IsDelete == false)
                .FirstOrDefault(t => t.Title.ToLower().Trim() == titles.Title.ToLower().Trim());

            if(isExist != null)
            {
                if(isExist.Id != t.Id)
                {
                    ModelState.AddModelError("Title", "This name already has. Please write another name");
                    return View(t);
                }
            }

            t.Title = titles.Title;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Titles title = await _context.Titles.FindAsync(id);
            if (title == null) return NotFound();
            int count = _context.Sliders.Count();
            return View(title);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Titles title = _context.Titles.FirstOrDefault(c => c.Id == id);
            if (title == null) return NotFound();

            if (!title.IsDelete)
                title.IsDelete = true;
            else
                title.IsDelete = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
