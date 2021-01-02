using Backend_Project.DAL;
using Backend_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    [Authorize(Roles = "Admin, EventModerator")]
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.Where(cr => cr.isDelete == false)
                .Include(cr => cr.EventDetails)
                .Include(cr => cr.EventDetails.Speakers).ThenInclude(cr => cr.EventDetails.Speakers)
                .Include(cr => cr.TagsToEvents).ThenInclude(cr => cr.Tags)
                .OrderByDescending(cr => cr.CreatedTime).ToList();
            return View(events);
        }
    }
}
