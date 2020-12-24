using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Services = _context.Services.ToList(),
                About = _context.Abouts.FirstOrDefault(),
                Titles = _context.Titles.ToList(),
                Courses = _context.Courses.Where(c=>c.isDelete==false).ToList(),
                Notices = _context.Notices.Include(n=>n.Boards).ToList(),
                Events = _context.Events.Where(e=>e.isDelete==false).ToList()

            };
            return View(homeVM);
        }

       
    }
}
