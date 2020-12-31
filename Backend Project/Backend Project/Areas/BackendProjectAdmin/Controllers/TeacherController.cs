using Backend_Project.DAL;
using Backend_Project.Models;
using Eduhome.Extentions;
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
    [Authorize(Roles = "Admin, TeacherModerator")]
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Teachers> teachers = _context.Teachers.Where(cr => cr.IsDelete == false)
                .Include(cr => cr.TeachersDetail).OrderByDescending(c=>c.CreatedTime).ToList();
            return View(teachers);
        }

        #region CRUD
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teachers teachers)
        {

            Teachers isExist = _context.Teachers.Where(cr => cr.IsDelete == false)
                .FirstOrDefault(cr => cr.Fullname.ToLower() == teachers.Fullname.ToLower());


            Teachers newTeacher = new Teachers();
            TeachersDetail newTeachersDetail = new TeachersDetail();

            if (teachers.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image cannot be empty");
                return View();
            }


            if (!teachers.Photo.IsImage())
            {
                ModelState.AddModelError("Photos", $"{teachers.Photo.FileName} - not image type");
                return View(newTeacher);
            }

            string folder = Path.Combine("img", "teacher");
            string fileName = await teachers.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return Content("Error");
            }

            newTeacher.Image = fileName;
            newTeacher.Fullname = teachers.Fullname;
            teachers.CreatedTime = DateTime.Now;
            newTeacher.CreatedTime = teachers.CreatedTime;
            await _context.AddAsync(newTeacher);
            await _context.SaveChangesAsync();

            #region About
            newTeachersDetail.AboutMe = teachers.TeachersDetail.AboutMe;
            newTeachersDetail.Degree = teachers.TeachersDetail.Degree;
            newTeachersDetail.Experience = teachers.TeachersDetail.Experience;
            newTeachersDetail.Hobbies = teachers.TeachersDetail.Hobbies;
            newTeachersDetail.Faculty = teachers.TeachersDetail.Faculty;
            #endregion

            #region Contact
            newTeachersDetail.Email = teachers.TeachersDetail.Email;
            newTeachersDetail.PhoneNumber = teachers.TeachersDetail.PhoneNumber;
            newTeachersDetail.Skype = teachers.TeachersDetail.Skype;
            newTeachersDetail.Facebook = teachers.TeachersDetail.Facebook;
            newTeachersDetail.Pinterest = teachers.TeachersDetail.Pinterest;
            newTeachersDetail.Vimeo = teachers.TeachersDetail.Vimeo;
            newTeachersDetail.Twitter = teachers.TeachersDetail.Twitter;
            #endregion

            #region Skills
            newTeachersDetail.Language = teachers.TeachersDetail.Language;
            newTeachersDetail.Design = teachers.TeachersDetail.Design;
            newTeachersDetail.TeamLeader = teachers.TeachersDetail.TeamLeader;
            newTeachersDetail.Innovation = teachers.TeachersDetail.Innovation;
            newTeachersDetail.Development = teachers.TeachersDetail.Development;
            newTeachersDetail.Communication = teachers.TeachersDetail.Communication;
            #endregion
            
            newTeachersDetail.TeachersId = newTeacher.Id;
            await _context.AddAsync(newTeachersDetail);
            await _context.SaveChangesAsync();

            
            
            return RedirectToAction(nameof(Index));
            //return Content(newCourseDetail.Id.ToString());
        }
        #endregion

        #region Update
        //public IActionResult Update(int? id)
        //{
        //    Course course = _context.Courses.Where(cr => cr.isDelete == false)
        //        .Include(cr => cr.CourseDetail).Include(cr => cr.TagCourses).ThenInclude(cr => cr.Tags)
        //        .FirstOrDefault(cr => cr.Id == id);
        //    return View(course);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, Course course)
        //{
        //    if (id == null) return NotFound();

        //    Course courseOld = await _context.Courses.Include(c => c.CourseDetail).FirstOrDefaultAsync(c => c.Id == id);

        //    Course isExist = _context.Courses.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);

        //    if (isExist != null)
        //    {
        //        if (isExist.Id != courseOld.Id)
        //        {
        //            ModelState.AddModelError("", "This name already has. Please write another name");
        //            return Content("e");
        //        }
        //    }

        //    if (course == null) return Content("Null");
        //    if (course.Photo != null)
        //    {
        //        if (!course.Photo.IsImage())
        //        {
        //            ModelState.AddModelError("Photos", $"{course.Photo.FileName} - not image type");
        //            return View(courseOld);
        //        }

        //        string folder = Path.Combine("img", "course");
        //        string fileName = await course.Photo.SaveImageAsync(_env.WebRootPath, folder);
        //        //string fileName = await course.Photo.SaveImageAsync(_env.)
        //        if (fileName == null)
        //        {
        //            return Content("Error");
        //        }

        //        Helper.DeleteImage(_env.WebRootPath, folder, courseOld.Image);
        //        courseOld.Image = fileName;
        //    }

        //    #region Update line
        //    courseOld.CourseName = course.CourseName;
        //    courseOld.CourseDescription = course.CourseDescription;
        //    courseOld.CourseDetail.AboutCourseDescription = course.CourseDetail.AboutCourseDescription;
        //    courseOld.CourseDetail.HowToApplyExplaining = course.CourseDetail.HowToApplyExplaining;
        //    courseOld.CourseDetail.CertificationExplain = course.CourseDetail.CertificationExplain;
        //    courseOld.CourseDetail.Starts = course.CourseDetail.Starts;
        //    courseOld.CourseDetail.Duration = course.CourseDetail.Duration;
        //    courseOld.CourseDetail.ClassDuration = course.CourseDetail.ClassDuration;
        //    courseOld.CourseDetail.SkillLevel = course.CourseDetail.SkillLevel;
        //    courseOld.CourseDetail.Language = course.CourseDetail.Language;
        //    courseOld.CourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
        //    courseOld.CourseDetail.StudentsCount = course.CourseDetail.StudentsCount;
        //    courseOld.CourseDetail.Assesments = course.CourseDetail.Assesments;
        //    courseOld.CourseDetail.CoursePrice = course.CourseDetail.CoursePrice;
        //    #endregion


        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion

        #region Delete and Detail

        //public async Task<IActionResult> Detail(int? id)
        //{
        //    if (id == null) return NotFound();
        //    Course course = await _context.Courses.Include(c => c.CourseDetail).FirstOrDefaultAsync(c => c.Id == id);
        //    if (course == null) return NotFound();
        //    return View(course);
        //}
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return NotFound();
        //    Course course = await _context.Courses.FindAsync(id);
        //    if (course == null) return NotFound();
        //    return View(course);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public async Task<IActionResult> DeletePost(int? id)
        //{
        //    if (id == null) return NotFound();
        //    Course course = _context.Courses.FirstOrDefault(c => c.Id == id);
        //    if (course == null) return NotFound();

        //    if (!course.isDelete)
        //    {
        //        course.isDelete = true;
        //        course.DeletedTime = DateTime.Now;
        //    }
        //    else
        //        course.isDelete = false;

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion
        #endregion
    }
}
