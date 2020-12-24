using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class EduhomeViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public EduhomeViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await Task.FromResult(_context.Abouts.FirstOrDefault()));
        }
    }
}
