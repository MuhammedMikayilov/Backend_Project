using Backend_Project.DAL;
using Backend_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Subscribe(string EmailSubscribe)
        {

            if (!EmailSubscribe.Contains("@"))
            {
                return RedirectToAction("ErrorPage", "Home");
            }

            EmailSubs email = new EmailSubs()
            {
                Email = EmailSubscribe
            };
            await _context.EmailSubs.AddAsync(email);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
