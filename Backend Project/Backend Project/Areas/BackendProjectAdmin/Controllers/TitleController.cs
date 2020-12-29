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
            return View(_context.Titles.Where(t=>t.IsDelete == false).ToList());
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

            title.IsDelete = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
