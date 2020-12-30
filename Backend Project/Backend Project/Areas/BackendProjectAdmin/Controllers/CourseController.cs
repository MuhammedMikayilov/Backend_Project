using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    [Authorize(Roles = "Admin")]
    //[Authorize(Roles = "CourseModerator")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Course> courses = _context.Courses.Where(cr => cr.isDelete == false)
                .Include(cr => cr.CourseDetail).ToList();
            return View(courses);
        }
        public IActionResult Update(int? id)
        {
            return View(_context.Courses.Where(cr=>cr.isDelete == false)
                .Include(cr=>cr.CourseDetail).Include(cr=>cr.TagCourses).ThenInclude(cr=>cr.Tags)
                .FirstOrDefault(cr=>cr.Id == id));
        }
        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Course course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            if (!course.isDelete)
            {
                course.isDelete = true;
                course.DeletedTime = DateTime.Now;
            }
            else
                course.isDelete = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion




    }
}
