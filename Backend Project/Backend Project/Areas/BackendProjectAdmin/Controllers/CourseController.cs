using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Extentions;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    [Authorize(Roles = "Admin, CourseModerator")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Course> courses = _context.Courses.Where(cr => cr.isDelete == false)
                .Include(cr => cr.CourseDetail).ToList();
            return View(courses);
        }
        public IActionResult Update(int? id)
        {
            Course course = _context.Courses.Where(cr => cr.isDelete == false)
                .Include(cr => cr.CourseDetail).Include(cr => cr.TagCourses).ThenInclude(cr => cr.Tags)
                .FirstOrDefault(cr => cr.Id == id);
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course)
        {
            if (id == null) return NotFound();

            Course courseOld = await _context.Courses.Include(c=>c.CourseDetail).FirstOrDefaultAsync(c=>c.Id==id);

            Course isExist = _context.Courses.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);
            
            if (isExist != null)
            {
                if (isExist.Id != courseOld.Id)
                {
                    ModelState.AddModelError("", "This name already has. Please write another name");
                    return Content("e");
                }
            }

            if (course == null) return Content("Null");
            if (course.Photo != null)
            {
                if (!course.Photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{course.Photo.FileName} - not image type");
                    return View(courseOld);
                }
                //if (!course.Photo.MaxSize(200))
                //{
                //    ModelState.AddModelError("Photos", $"{course.Photo.FileName} - Max image length must be less than 200kb");
                //    return View(courseOld);
                //}


                string folder = Path.Combine("img", "course");
                string fileName = await course.Photo.SaveImageAsync(_env.WebRootPath, folder);
                //string fileName = await course.Photo.SaveImageAsync(_env.)
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, courseOld.Image);
                //_context.Courses.Remove(courseOld);
                courseOld.Image = fileName;
            }

            courseOld.CourseName = course.CourseName;
            courseOld.CourseDescription = course.CourseDescription;
            courseOld.CourseDetail.AboutCourseDescription = course.CourseDetail.AboutCourseDescription;
            courseOld.CourseDetail.HowToApplyExplaining = course.CourseDetail.HowToApplyExplaining;
            courseOld.CourseDetail.CertificationExplain = course.CourseDetail.CertificationExplain;
            courseOld.CourseDetail.Starts = course.CourseDetail.Starts;
            courseOld.CourseDetail.Duration = course.CourseDetail.Duration;
            courseOld.CourseDetail.ClassDuration = course.CourseDetail.ClassDuration;
            courseOld.CourseDetail.SkillLevel = course.CourseDetail.SkillLevel;
            courseOld.CourseDetail.Language = course.CourseDetail.Language;
            courseOld.CourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
            courseOld.CourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
            courseOld.CourseDetail.Assesments = course.CourseDetail.Assesments;
            courseOld.CourseDetail.CoursePrice = course.CourseDetail.CoursePrice;


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
