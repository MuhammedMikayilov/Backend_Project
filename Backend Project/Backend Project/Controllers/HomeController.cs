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
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Services = _context.Services.ToList(),
                Titles = _context.Titles.ToList(),
                Testimonials = _context.Testimonials.ToList()
            };
            return View(homeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromForm] string email)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            bool subscription = _context.EmailSubs.Any(e => e.Email == email);
            ViewBag.exist = subscription;

            var subscribe = new EmailSubs 
            {
                Email = email 
            };
            await _context.EmailSubs.AddAsync(subscribe);
            await _context.SaveChangesAsync();

            return Ok(subscribe.Id);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

       
    }
}
