using Backend_Project.DAL;
using Backend_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class BlogsViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public BlogsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? take)
        {
            List<Blogs> blogs = new List<Blogs>();
            blogs = _context.Blogs.Where(b => b.isDelete == false).Take((int)take).ToList();
            return View(blogs);
        }
    }
}
