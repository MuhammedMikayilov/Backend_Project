using Backend_Project.DAL;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            HomeVM homeVM = new HomeVM
            {
                About = _context.Abouts.FirstOrDefault()
            };
            return View(await Task.FromResult(homeVM));
        }
    }
}
