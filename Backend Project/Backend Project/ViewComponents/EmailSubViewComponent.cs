﻿using Backend_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class EmailSubViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public EmailSubViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await Task.FromResult(_context.EmailSubs.ToList()));
        }
    }
}