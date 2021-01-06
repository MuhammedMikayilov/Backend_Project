using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public IActionResult Index(int? page = 1)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Courses
               .Where(blg => blg.isDelete == false).Count() / 6);
            ViewBag.Page = page;
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction("ErrorPage", "Home"); ;

            CourseVM courseVM = new CourseVM()
            {
                Categories = _context.Categories.ToList(),
                Course = _context.Courses.Where(c => c.isDelete == false).Include(c => c.CourseDetail)
                .Include(c => c.CategoryCourses).ThenInclude(c => c.Categories)
                .Include(c => c.TagCourses).ThenInclude(c => c.Tags)
                .FirstOrDefault(c => c.Id == id)
            };
            return View(courseVM);
        }

        public IActionResult FilterCategory(int? id)
        {
            
            if (id == null) return NotFound();
            List<CategoryCourse> categoryCourses = _context.CategoryCourses.Include(c => c.Course)
                .Where(c => c.CategoriesId == id).ToList();
            if (categoryCourses == null) return RedirectToAction("ErrorPage", "Home");
            List<Course> courses = categoryCourses.Select(x => x.Course).Where(c => c.isDelete == false).ToList();
            if (courses == null) return NotFound();

            return View("~/Views/Shared/Components/Course/Default.cshtml", courses);
        }

        public IActionResult FilterTags(int? id)
        {

            if (id == null) return NotFound();
            List<TagCourse> coursesCategory = _context.TagCourses.Include(c => c.Course)
                .Where(c => c.TagsId == id).ToList();
            if (coursesCategory == null) return NotFound();
            List<Course> courses = coursesCategory.Select(x => x.Course).Where(c => c.isDelete == false).ToList();
            if (courses == null) return NotFound();

            return View(courses);
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
