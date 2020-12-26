using Backend_Project.DAL;
using Backend_Project.Models;
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
        public IActionResult Index()
        {
            return View(_context.Events.Where(e=>e.isDelete==false).Take(6).ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Event events = _context.Events.Where(c => c.isDelete == false).Include(e=>e.EventDetails).Include(e=>e.EventDetails.Speakers)
                .FirstOrDefault(e => e.Id == id);
            if (events == null) NotFound();
            return View(events);
        }
    }
}
