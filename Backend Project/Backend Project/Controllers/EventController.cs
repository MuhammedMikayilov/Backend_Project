using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page = 1)
        {
            
            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Events
                .Where(blg => blg.isDelete == false).Count() / 6);
            if (page == null) return View(_context.Events.Where(e => e.isDelete == false).Take(6).ToList());
            return View(_context.Events.Where(e=>e.isDelete==false).Skip(((int)page - 1)*6).Take(6).ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Event events = _context.Events.Where(c => c.isDelete == false)
                .Include(e=>e.EventDetails).Include(e=>e.EventDetails.Speakers)
                .Include(e=>e.TagsToEvents).ThenInclude(e=>e.Tags)
                .FirstOrDefault(e => e.Id == id);

            if (events == null) NotFound();
            return View(events);
        }

        public IActionResult FilterCategory(int? id)
        {

            if (id == null) return NotFound();
            List<CategoryEvents> categoryEvents = _context.CategoryEvents.Include(c => c.Event)
                .Where(c => c.CategoriesId == id).ToList();
            if (categoryEvents == null) return RedirectToAction("ErrorPage", "Home");
            List<Event> events = categoryEvents.Select(x => x.Event).Where(c => c.isDelete == false).ToList();
            if (events == null) return NotFound();

            return View("~/Views/Shared/Components/Blogs/Default.cshtml", events);
        }

        public IActionResult Search(string search)
        {
            if (search == null) return View(_context.Blogs.Where(blg => blg.isDelete == false).ToList());
            IEnumerable<Event> events = _context.Events
                .Where(blg => blg.isDelete == false && blg.Title.Contains(search))
                .OrderByDescending(blg => blg.Id).Take(8);
            return PartialView("_SearchEventPartial", events);
        }
    }
}
