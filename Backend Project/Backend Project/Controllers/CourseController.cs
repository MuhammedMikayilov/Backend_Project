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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Courses
               .Where(blg => blg.isDelete == false).Count() / 6);
            ViewBag.Page = page;
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();

            Course course = _context.Courses.Where(c => c.isDelete == false).Include(c => c.CourseDetail)
                .Include(c => c.CategoryCourses).ThenInclude(c => c.Categories)
                .Include(c => c.TagCourses).ThenInclude(c => c.Tags)
                .FirstOrDefault(c => c.Id == id);
            
            if (course == null) NotFound();
            return View(course);
        }

        public IActionResult Search(string search)
        {
            if (search == null) return View(_context.Courses.Where(blg => blg.isDelete == false).ToList());
            IEnumerable<Course> course = _context.Courses
                .Where(blg => blg.isDelete == false && blg.CourseName.Contains(search))
                .OrderByDescending(blg => blg.Id).Take(8);
            return PartialView("_SearchCoursePartial", course);
        }

    }
}
