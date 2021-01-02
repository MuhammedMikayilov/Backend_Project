﻿using Backend_Project.DAL;
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
    [Authorize(Roles = "Admin, EventModerator")]
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.Where(cr => cr.isDelete == false)
                .Include(cr => cr.EventDetails)
                .Include(cr => cr.EventDetails.Speakers)
                .Include(cr => cr.TagsToEvents).ThenInclude(cr => cr.Tags)
                .OrderByDescending(cr => cr.CreatedTime).ToList();
            return View(events);
        }

        #region CRUD
        #region Create
        public IActionResult Create()
        {
            //ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events, List<int> TagId, List<int> SpeakerId, string subject, string message)
        {
            //ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExist = _context.Events.Where(cr => cr.isDelete == false)
                .Any(cr => cr.Title == events.Title);

            if (isExist)
            {
                ModelState.AddModelError("", "This name already exist");
                return View();
            }

            Event newEvent = new Event
            {
                Title = events.Title,
            };

            EventDetails newCourseDetail = new EventDetails();

            if (!events.Photo.IsImage())
            {
                ModelState.AddModelError("Photos", $"{events.Photo.FileName} - not image type");
                return View(newEvent);
            }

            string folder = Path.Combine("img", "course");
            string fileName = await events.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return Content("Error");
            }
            newEvent.Image = fileName;

            #region Many to Many
            List<Speakers> eventSpeakers = new List<Speakers>();
            List<TagsToEvents> tagCourses = new List<TagsToEvents>();


            if (TagId.Count == 0)
            {
                ModelState.AddModelError("", "Tag cannot be empty");
                return View();
            }

            foreach (var item in TagId)
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
        #endregion
    }
}
