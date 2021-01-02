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
            Teachers newTeacher = new Teachers();
            TeachersDetail newTeachersDetail = new TeachersDetail();


            if (teachers.Fullname == null)
            {
                ModelState.AddModelError("Fullname", "Fullname cannot be empty");
                return View();
            }

            if (teachers.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.AboutMe == null)
            {
                ModelState.AddModelError("", "About Cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.Degree == null)
            {
                ModelState.AddModelError("", "TeachersDetail Degree Cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.Email == null)
            {
                ModelState.AddModelError("", "Email Cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.Experience == null)
            {
                ModelState.AddModelError("", "Experience Cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.Hobbies == null)
            {
                ModelState.AddModelError("", "Hobbies Cannot be empty");
                return View();
            }

            if (teachers.TeachersDetail.Faculty == null)
            {
                ModelState.AddModelError("", "Faculty Cannot be empty");
                return View();
            }

            if (newTeacher == null) return NotFound();
            if (newTeachersDetail == null) return NotFound();



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
            newTeacher.Speciality = teachers.Speciality;
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
        public IActionResult Update(int? id)
        {
            Teachers teachers = _context.Teachers.Where(cr => cr.IsDelete == false)
                .Include(cr => cr.TeachersDetail)
                .FirstOrDefault(cr => cr.Id == id);
            return View(teachers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Teachers teachers)
        {
            if (id == null) return NotFound();

            Teachers oldTeacher = await _context.Teachers.Include(c => c.TeachersDetail).FirstOrDefaultAsync(c => c.Id == id);

            Course isExist = _context.Courses.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);

            if (isExist != null)
            {
                if (isExist.Id != oldTeacher.Id)
                {
                    ModelState.AddModelError("", "This name already has. Please write another name");
                    return Content("e");
                }
            }

            if (teachers == null) return Content("Null");
            if (teachers.Photo != null)
            {
                if (!teachers.Photo.IsImage())
                {
                    ModelState.AddModelError("Photos", $"{teachers.Photo.FileName} - not image type");
                    return View(teachers);
                }

                string folder = Path.Combine("img", "course");
                string fileName = await teachers.Photo.SaveImageAsync(_env.WebRootPath, folder);
                //string fileName = await course.Photo.SaveImageAsync(_env.)
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, oldTeacher.Image);
                oldTeacher.Image = fileName;
            }

            #region Update line
            oldTeacher.Fullname = teachers.Fullname;
            oldTeacher.Speciality = teachers.Speciality;
            //About part start
            oldTeacher.TeachersDetail.AboutMe = teachers.TeachersDetail.AboutMe;
            oldTeacher.TeachersDetail.Degree = teachers.TeachersDetail.Degree;
            oldTeacher.TeachersDetail.Experience = teachers.TeachersDetail.Experience;
            oldTeacher.TeachersDetail.Hobbies = teachers.TeachersDetail.Hobbies;
            oldTeacher.TeachersDetail.Faculty = teachers.TeachersDetail.Faculty;
            //About part end

            //Information part start
            oldTeacher.TeachersDetail.Email = teachers.TeachersDetail.Email;
            oldTeacher.TeachersDetail.PhoneNumber = teachers.TeachersDetail.PhoneNumber;
            oldTeacher.TeachersDetail.Skype = teachers.TeachersDetail.Skype;
            oldTeacher.TeachersDetail.Facebook = teachers.TeachersDetail.Facebook;
            oldTeacher.TeachersDetail.Pinterest = teachers.TeachersDetail.Pinterest;
            oldTeacher.TeachersDetail.Vimeo = teachers.TeachersDetail.Vimeo;
            oldTeacher.TeachersDetail.Twitter = teachers.TeachersDetail.Twitter;
            //Information part end

            //Skills part start
            oldTeacher.TeachersDetail.Language = teachers.TeachersDetail.Language;
            oldTeacher.TeachersDetail.Design = teachers.TeachersDetail.Design;
            oldTeacher.TeachersDetail.TeamLeader = teachers.TeachersDetail.TeamLeader;
            oldTeacher.TeachersDetail.Innovation = teachers.TeachersDetail.Innovation;
            oldTeacher.TeachersDetail.Development = teachers.TeachersDetail.Development;
            oldTeacher.TeachersDetail.Communication = teachers.TeachersDetail.Communication;
            //Skills part end
            #endregion


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete and Detail

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Teachers teachers = await _context.Teachers
                .Include(c => c.TeachersDetail).FirstOrDefaultAsync(c => c.Id == id);
            if (teachers == null) return NotFound();
            return View(teachers);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Teachers teachers = await _context.Teachers.Include(t=>t.TeachersDetail).FirstOrDefaultAsync(t=>t.Id==id);
            if (teachers == null) return NotFound();
            return View(teachers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Teachers teachers = _context.Teachers.FirstOrDefault(c => c.Id == id);
            if (teachers == null) return NotFound();

            teachers.IsDelete = true;
            teachers.DeletedTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #endregion
    }
}
