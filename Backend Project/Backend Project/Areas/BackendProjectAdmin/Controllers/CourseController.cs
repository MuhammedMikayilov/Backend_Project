using Backend_Project.Areas.BackendProjectAdmin.ViewModels;
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
using System.Net;
using System.Net.Mail;
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
                .Include(cr => cr.CourseDetail).Include(cr => cr.CategoryCourses).ThenInclude(cr => cr.Categories)
                .OrderByDescending(cr => cr.CreatedTime).ToList();
            return View(courses);
        }

        #region CRUD
        #region Create
        public IActionResult Create()
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course, List<int> CategId, List<int> TagId, string subject, string message)
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExist = _context.Courses.Where(cr => cr.isDelete == false)
                .Any(cr => cr.CourseName == course.CourseName);

            if (isExist)
            {
                ModelState.AddModelError("Course.CourseName", "This name already exist");
                return View();
            }

            Course newCourse = new Course
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription
            };

            CourseDetail newCourseDetail = new CourseDetail();

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

            #region Many to Many
            List<CategoryCourse> categoryCourses = new List<CategoryCourse>();
            List<TagCourse> tagCourses = new List<TagCourse>();

            if (CategId.Count == 0)
            {
                ModelState.AddModelError("", "Category cannot be empty");
                return View();
            }

            foreach (var item in CategId)
            {
                CategoryCourse categoryCourse = new CategoryCourse()
                {
                    CourseId = newCourse.Id,
                    CategoriesId = item
                };
                categoryCourses.Add(categoryCourse);
            }

            if (TagId.Count == 0)
            {
                ModelState.AddModelError("", "Tag cannot be empty");
                return View();
            }

            foreach (var item in TagId)
            {
                TagCourse tagCourse = new TagCourse()
                {
                    CourseId = newCourse.Id,
                    TagsId = item
                };
                tagCourses.Add(tagCourse);
            }
            #endregion
            #region Courses
            newCourse.CategoryCourses = categoryCourses;
            newCourse.TagCourses = tagCourses;
            course.CreatedTime = DateTime.Now;
            newCourse.CreatedTime = course.CreatedTime;
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
            #endregion
            #region CourseDetail
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
            #endregion
            #region EmailSender


            //var senderEmail = new MailAddress("mahammadsm@code.edu.az", "Muhammed");
            //var receiverEmail = new MailAddress("muhammedmikayilov@gmail.com", "Receiver");
            //var password = "Your Email Password here";
            //string sub = "Hello World";
            //var body = "This is test";
            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(senderEmail.Address, password)
            //};
            //using (var mess = new MailMessage(senderEmail, receiverEmail)
            //{
            //    Subject = subject,
            //    Body = body
            //})
            //{
            //    smtp.Send(mess);
            //}
            ////return View();

            #endregion

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            CreateCourseVM createCourseVM = new CreateCourseVM
            {
                Course = _context.Courses.Where(cr => cr.isDelete == false)
                .Include(cr => cr.CourseDetail).Include(cr => cr.TagCourses).ThenInclude(cr => cr.Tags)
                .FirstOrDefault(cr => cr.Id == id)

            };
            return View(createCourseVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Course course, List<int> CategId, List<int> TagId)
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (id == null) return NotFound();

            CreateCourseVM createCourseVM = new CreateCourseVM
            {
                Course = _context.Courses.Where(cr => cr.isDelete == false)
               .Include(cr => cr.CourseDetail).Include(cr => cr.TagCourses).ThenInclude(cr => cr.Tags)
               .FirstOrDefault(cr => cr.Id == id)

            };
            Course courseOld = await _context.Courses.Include(c => c.CourseDetail).FirstOrDefaultAsync(c => c.Id == id);
            Course isExist = _context.Courses.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);
            bool exist = _context.Courses.Where(cr => cr.isDelete == false).Any(cr => cr.CourseName == course.CourseName);

            if (exist)
            {
                if (isExist.CourseName != course.CourseName)
                {
                    ModelState.AddModelError("Course.CourseName", "This name already has. Please write another name");
                    return View(createCourseVM);
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
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, courseOld.Image);
                courseOld.Image = fileName;
            }

            #region Many to Many
            //List<CategoryCourse> categoryCourses = new List<CategoryCourse>();
            //List<TagCourse> tagCourses = new List<TagCourse>();

            //if (CategId.Count == 0)
            //{
            //    ModelState.AddModelError("", "Category cannot be empty");
            //    return View();
            //}

            //foreach (var item in CategId)
            //{
            //    CategoryCourse categoryCourse = new CategoryCourse()
            //    {
            //        CourseId = course.Id,
            //        CategoriesId = item
            //    };
            //    categoryCourses.Add(categoryCourse);
            //}

            //if (TagId.Count == 0)
            //{
            //    ModelState.AddModelError("", "Tag cannot be empty");
            //    return View();
            //}

            //foreach (var item in TagId)
            //{
            //    TagCourse tagCourse = new TagCourse()
            //    {
            //        CourseId = newCourse.Id,
            //        TagsId = item
            //    };
            //    tagCourses.Add(tagCourse);
            //}
            #endregion

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
        #endregion

        #region Delete and Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Course course = await _context.Courses.Include(c => c.CourseDetail).FirstOrDefaultAsync(c => c.Id == id);
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
        #endregion




    }
}
