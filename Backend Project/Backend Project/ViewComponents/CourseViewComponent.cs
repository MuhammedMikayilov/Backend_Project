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
    public class CourseViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public CourseViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? take)
        {
            if (take == null) return View();
            List<Course> course = _context.Courses.Where(c => c.isDelete == false)
                .Take((int)take).Include(c=>c.CategoryCourses).ThenInclude(c=>c.Categories).ToList();
            return View(await Task.FromResult(course));
        }
    }
}
