using Backend_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class LatestBlogViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public LatestBlogViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Blogs.Where(blg => blg.isDelete == false)
                .OrderByDescending(blg => blg.DateWrite).Take(3).ToList());
        }
    }
}
