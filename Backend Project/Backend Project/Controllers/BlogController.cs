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
        private readonly IViewComponentHelper _componentHelper;

        public BlogController(AppDbContext context, IViewComponentHelper componentHelper)
        {
            _context = context;
            _componentHelper = componentHelper;
        }
        public IActionResult Index(int? page)
        {
            if (page == null) return View();
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            //Blogs blogs = _context.Blogs.Include(blg => blg.Detail).FirstOrDefault(blg => blg.Id == id);

            Blogs blogs = _context.Blogs.Where(blg => blg.isDelete == false).Include(blg => blg.Detail).Include(blg => blg.TagToBlogs)
                .ThenInclude(blg => blg.Tags).FirstOrDefault(blg => blg.Id == id);
            return View(blogs);
        }

        public IActionResult Search(string search)
        {
            if (search == null) return View(_context.Blogs.Where(blg=>blg.isDelete==false).ToList());
            IEnumerable<Blogs> blogs = _context.Blogs
                .Where(blg => blg.isDelete==false && blg.Title.Contains(search))
                .OrderByDescending(blg => blg.Id).Take(8);
            return PartialView("_SearchPartial", blogs);
        }

    }
}
