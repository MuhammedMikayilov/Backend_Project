﻿using Backend_Project.DAL;
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
        public IActionResult Subscribe(string val)
        {
            //if (val == null) RedirectToAction("NotFound", "Home");

            //EmailSubs newEmailSub = new EmailSubs() 
            //{ 
            //    Email = 
            //};

            string t = "selam";

            return Content(t);
        }
    }
}
