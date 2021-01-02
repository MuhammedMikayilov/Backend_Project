﻿using Backend_Project.DAL;
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

        public IActionResult Search(string search)
        {
            if (search == null) return View(_context.Courses.Where(blg => blg.isDelete == false).ToList());
            IEnumerable<Course> course = _context.Courses
                .Where(blg => blg.isDelete == false && blg.CourseName.Contains(search))
                .OrderByDescending(blg => blg.Id).Take(8);
            return PartialView("_SearchCoursePartial", course);
        }

      

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Detail")]
        //public ActionResult SendEmail(string receiver, string subject, string message)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var senderEmail = new MailAddress("mahammadsm@code.edu.az", "Mahammad");
        //            var receiverEmail = new MailAddress(receiver, "Receiver");
        //            var password = "M34269594152875d";
        //            var sub = subject;
        //            var body = message;
        //            var smtp = new SmtpClient
        //            {
        //                Host = "smtp.gmail.com",
        //                Port = 587,
        //                EnableSsl = true,
        //                DeliveryMethod = SmtpDeliveryMethod.Network,
        //                UseDefaultCredentials = false,
        //                Credentials = new NetworkCredential(senderEmail.Address, password)
        //            };
        //            using (var mess = new MailMessage(senderEmail, receiverEmail)
        //            {
        //                Subject = subject,
        //                Body = body
        //            })
        //            {
        //                smtp.Send(mess);
        //            }
        //            return RedirectToAction(nameof(Detail));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Some Error";
        //    }
        //    return View();
        //}

    }
}
