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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {

            Course isExist = _context.Courses.Where(cr => cr.isDelete == false)
                .FirstOrDefault(cr => cr.CourseName.ToLower() == course.CourseName.ToLower());

            
            Course newCourse = new Course();
            CourseDetail newCourseDetail = new CourseDetail();

            if(course.Photo == null)
            {
                ModelState.AddModelError("Photo","Image cannot be empty");
                return View();
            }

            if (course.CourseDetail.CoursePrice == null)
            {
                ModelState.AddModelError("CourseDetail_CoursePrice", "Price cannot be empty");
                return View();
            }

            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photos", $"{course.Photo.FileName} - not image type");
                return View(newCourse);
            }

            string folder = Path.Combine("img", "course");
            string fileName = await course.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return Content("Error");
            }

            newCourse.Image = fileName;
            newCourse.CourseName = course.CourseName;
            newCourse.CourseDescription = course.CourseDescription;
            await _context.AddAsync(newCourse);
            await _context.SaveChangesAsync();

            newCourseDetail.AboutCourseDescription = course.CourseDetail.AboutCourseDescription;
            newCourseDetail.HowToApplyExplaining = course.CourseDetail.HowToApplyExplaining;
            newCourseDetail.CertificationExplain = course.CourseDetail.CertificationExplain;
            newCourseDetail.Starts = course.CourseDetail.Starts;
            newCourseDetail.Duration = course.CourseDetail.Duration;
            newCourseDetail.ClassDuration = course.CourseDetail.ClassDuration;
            newCourseDetail.SkillLevel = course.CourseDetail.SkillLevel;
            newCourseDetail.Language = course.CourseDetail.Language;
            newCourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
            newCourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
            newCourseDetail.Assesments = course.CourseDetail.Assesments;
            newCourseDetail.CoursePrice = course.CourseDetail.CoursePrice;
            newCourseDetail.CourseId = newCourse.Id;
            await _context.AddAsync(newCourseDetail);
            await _context.SaveChangesAsync();

            //

            return RedirectToAction(nameof(Index));
            //return Content(newCourseDetail.Id.ToString());
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

                string folder = Path.Combine("img", "course");
                string fileName = await course.Photo.SaveImageAsync(_env.WebRootPath, folder);
                //string fileName = await course.Photo.SaveImageAsync(_env.)
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, courseOld.Image);
                courseOld.Image = fileName;
            }

            #region Update line
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
            #endregion


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #region Delete and Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _context.Courses.Include(c=>c.CourseDetail).FirstOrDefaultAsync(c=>c.Id==id);
            if (course == null) return NotFound();
            return View(course);
        }
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
