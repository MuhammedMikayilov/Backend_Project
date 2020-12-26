using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            //Blogs blogs = _context.Blogs.Include(blg => blg.Detail).FirstOrDefault(blg => blg.Id == id);

            Blogs blogs = _context.Blogs.Where(blg => blg.isDelete == false).Include(blg => blg.Detail).Include(blg => blg.TagToBlogs)
                .ThenInclude(blg => blg.Tags).FirstOrDefault(blg => blg.Id == id);

            BlogsVM blogsVM = new BlogsVM()
            {
                Blog = _context.Blogs.Where(blg=>blg.isDelete==false).Include(blg => blg.Detail).Include(blg=>blg.TagToBlogs)
                .ThenInclude(blg=>blg.Tags).FirstOrDefault(blg => blg.Id == id),
                Blogs = _context.Blogs.Where(blg=>blg.isDelete==false)
                .OrderByDescending(blg=>blg.DateWrite).Take(3).ToList()
            };
            return View(blogs);
        }
    }
}
