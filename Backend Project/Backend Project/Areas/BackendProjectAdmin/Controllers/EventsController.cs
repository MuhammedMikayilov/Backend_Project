using Backend_Project.Areas.BackendProjectAdmin.ViewModels;
using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Eduhome.Extentions;
using Eduhome.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Roles = "Admin, EventModerator")]
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public EventsController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.Where(cr => cr.isDelete == false)
                .Include(cr => cr.EventDetails)
                //.Include(cr => cr.EventDetails.Speakers)
                .Include(cr => cr.TagsToEvents).ThenInclude(cr => cr.Tags)
                .OrderByDescending(cr => cr.CreatedTime).ToList();
            return View(events);
        }

        #region CRUD
        #region Create
        public IActionResult Create()
        {
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events, List<int> TagsId, List<int> SpeakerId)
        {
            ViewBag.Tags = _context.Tags.ToList();

            bool isExist = _context.Events.Where(cr => cr.isDelete == false)
                .Any(cr => cr.Title == events.Title);

            Event newEvent = new Event
            {
                Title = events.Title,
            };

            EventDetails newCourseDetail = new EventDetails();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Error");
                return View();
            }

            if (!events.Photo.IsImage())
            {
                ModelState.AddModelError("Event.Photo", $"{events.Photo.FileName} - not image type");
                return View(newEvent);
            }

            string folder = Path.Combine("img", "course");
            string fileName = await events.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return RedirectToAction("ErrorPage", "Home"); ;
            }
            newEvent.Image = fileName;

            #region Many to Many
            List<TagsToEvents> tagCourses = new List<TagsToEvents>();


            if (TagsId.Count == 0)
            {
                ModelState.AddModelError("", "Tag cannot be empty");
                return View();
            }

            foreach (var item in TagsId)
            {
                TagsToEvents tagCourse = new TagsToEvents()
                {
                    EventsId = newEvent.Id,
                    TagsId = item
                };
                tagCourses.Add(tagCourse);
            }

            #endregion
            #region Courses
            newEvent.TagsToEvents = tagCourses;
            events.CreatedTime = DateTime.Now;
            newEvent.CreatedTime = events.CreatedTime;
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            #endregion
            #region CourseDetail
            newCourseDetail.EventDescription = events.EventDetails.EventDescription;
            
            newCourseDetail.EventId = newEvent.Id;
            await _context.AddAsync(newCourseDetail);
            await _context.SaveChangesAsync();
            #endregion
            #region EmailSender
            List<EmailSubs> emails = _context.EmailSubs.ToList();
            foreach (EmailSubs email in emails)
            {
                string message = "Hello dear client. We have a new Event for you. You can look that." +
               "Kind Regard, Eduhome ";
                await SenderEmail(email.Email, "New Event at Eduhome", message);
            }
            #endregion

            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Update
        //public IActionResult Update(int? id)
        //{
        //    ViewBag.Categ = _context.Categories.ToList();
        //    ViewBag.Tags = _context.Tags.ToList();
        //    CreateCourseVM createCourseVM = new CreateCourseVM
        //    {
        //        Course = _context.Courses.Where(cr => cr.isDelete == false)
        //        .Include(cr => cr.CourseDetail).Include(cr => cr.TagCourses).ThenInclude(cr => cr.Tags)
        //        .FirstOrDefault(cr => cr.Id == id)

        //    };
        //    return View(createCourseVM);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int? id, Event course, List<int> CategId, List<int> TagId)
        //{
        //    ViewBag.Categ = _context.Categories.ToList();
        //    ViewBag.Tags = _context.Tags.ToList();
        //    if (id == null) return NotFound();

        //    CreateCourseVM createCourseVM = new CreateCourseVM
        //    {
        //        Event = _context.Events.Where(cr => cr.isDelete == false)
        //       .Include(cr => cr.EventDetails).Include(cr => cr.TagsToEvents).ThenInclude(cr => cr.Tags)
        //       .FirstOrDefault(cr => cr.Id == id)

        //    };
        //    Event oldEvent = await _context.Events.Include(c => c.EventDetails).FirstOrDefaultAsync(c => c.Id == id);
        //    Event isExist = _context.Events.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);
        //    bool exist = _context.Events.Where(cr => cr.isDelete == false).Any(cr => cr.Title == course.Title);

        //    if (exist)
        //    {
        //        if (isExist.Title != course.Title)
        //        {
        //            ModelState.AddModelError("Course.CourseName", "This name already has. Please write another name");
        //            return View(createCourseVM);
        //        }
        //    }

        //    if (course == null) return Content("Null");
        //    if (course.Photo != null)
        //    {
        //        if (!course.Photo.IsImage())
        //        {
        //            ModelState.AddModelError("Photos", $"{course.Photo.FileName} - not image type");
        //            return View(oldEvent);
        //        }

        //        string folder = Path.Combine("img", "course");
        //        string fileName = await course.Photo.SaveImageAsync(_env.WebRootPath, folder);
        //        if (fileName == null)
        //        {
        //            return Content("Error");
        //        }

        //        Helper.DeleteImage(_env.WebRootPath, folder, oldEvent.Image);
        //        oldEvent.Image = fileName;
        //    }

        //    #region Many to Many
        //    //List<CategoryCourse> categoryCourses = new List<CategoryCourse>();
        //    //List<TagCourse> tagCourses = new List<TagCourse>();

        //    //if (CategId.Count == 0)
        //    //{
        //    //    ModelState.AddModelError("", "Category cannot be empty");
        //    //    return View();
        //    //}

        //    //foreach (var item in CategId)
        //    //{
        //    //    CategoryCourse categoryCourse = new CategoryCourse()
        //    //    {
        //    //        CourseId = course.Id,
        //    //        CategoriesId = item
        //    //    };
        //    //    categoryCourses.Add(categoryCourse);
        //    //}

        //    //if (TagId.Count == 0)
        //    //{
        //    //    ModelState.AddModelError("", "Tag cannot be empty");
        //    //    return View();
        //    //}

        //    //foreach (var item in TagId)
        //    //{
        //    //    TagCourse tagCourse = new TagCourse()
        //    //    {
        //    //        CourseId = newCourse.Id,
        //    //        TagsId = item
        //    //    };
        //    //    tagCourses.Add(tagCourse);
        //    //}
        //    #endregion

        //    #region Update line
        //    #region Courses
        //    //oldEvent.TagsToEvents = ta;
        //    //events.CreatedTime = DateTime.Now;
        //    //newEvent.CreatedTime = events.CreatedTime;
        //    //await _context.Events.AddAsync(newEvent);
        //    await _context.SaveChangesAsync();
        //    #endregion
        //    #region CourseDetail
        //    await _context.SaveChangesAsync();
        //    #endregion
        //    #endregion
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}
        #endregion
        #endregion

        #region SenderEmail
        public async Task SenderEmail(string toEmail, string sub, string messageBody)
        {
            #region EmailSender
            var senderEmail = new MailAddress("mikayilov.muhammed.2021@gmail.com", "Muhammed");
            var receiverEmail = new MailAddress(toEmail, "");
            var password = "!23456789Mm";
            string subject = sub;
            var body = messageBody;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(mess);
            }
            //return View();

            #endregion
        }
        #endregion
    }
}
