using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend_Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;


        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page = 1)
        {
            //if (page == null) return View();

            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Blogs
               .Where(blg => blg.isDelete == false).Count() / 6);
            ViewBag.Page = page;
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            BlogVM blogVM = new BlogVM()
            {
                Blog = _context.Blogs.Where(blg => blg.isDelete == false).Include(blg => blg.BlogDetail)
                .Include(blg => blg.TagToBlogs).ThenInclude(blg => blg.Tags)
                .Include(blg => blg.CategoryBlogs).ThenInclude(blg => blg.Categories)
                .FirstOrDefault(blg => blg.Id == id),
                Categories = _context.Categories.ToList()
            };
            return View(blogVM);
        }

        public IActionResult FilterCategory(int? id)
        {

            if (id == null) return NotFound();
            List<CategoryBlogs> categoryBlogs = _context.CategoryBlogs.Include(c => c.Blogs)
                .Where(c => c.CategoriesId == id).ToList();
            if (categoryBlogs == null) return RedirectToAction("ErrorPage", "Home");
            List<Blogs> blogs = categoryBlogs.Select(x => x.Blogs).Where(c => c.isDelete == false).ToList();
            if (blogs == null) return NotFound();

            return View("~/Views/Shared/Components/Blogs/Default.cshtml", blogs);
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
