using Backend_Project.DAL;
using Backend_Project.Models;
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
    [Authorize(Roles = "Admin, BlogsWriter")]
    public class BlogsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public BlogsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Blogs> blogs = _context.Blogs.Where(blg => blg.isDelete == false)
                .Include(blg => blg.BlogDetail).OrderByDescending(blg=>blg.CreatedTime).ToList();
            return View(blogs);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            Blogs blog = await _context.Blogs.Include(blg => blg.BlogDetail).FirstOrDefaultAsync(blg => blg.Id == id);
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blogs blog)
        {
            if (blog == null) return RedirectToAction("ErrorPage", "Home");

            if (!ModelState.IsValid) return RedirectToAction("ErrorPage", "Home");

            Blogs blogs = new Blogs();
            BlogDetail blogDetail = new BlogDetail();
            bool isExist = _context.Blogs.Where(cr => cr.isDelete == false)
               .Any(cr => cr.Title == blog.Title);
            if (isExist)
            {
                ModelState.AddModelError("Blogs.Title", "This name already exist");
                return View();
            }
            #region Images
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("Photos", $"{blog.Photo.FileName} - not image type");
                return View(blogs);
            }

            string folder = Path.Combine("img", "blog");
            string fileName = await blog.Photo.SaveImageAsync(_env.WebRootPath, folder);
            if (fileName == null)
            {
                return Content("Error");
            }
            blogs.Image = fileName;
            #endregion
            #region SenderEmail
            List<EmailSubs> emails = _context.EmailSubs.ToList();
            foreach (EmailSubs email in emails)
            {
                string message = "Hello dear client. We have a new Blog for you. You can look that." +
               "Kind Regard, Eduhome ";
                await SenderEmail(email.Email, "New Blog", message);
            }
            #endregion

            blogs.Title = blog.Title;
            blogs.Author = blog.Author;
            blogs.DateWrite = blog.DateWrite;
            blog.CreatedTime = DateTime.Now;
            blogs.CreatedTime = blog.CreatedTime;
            await _context.Blogs.AddAsync(blogs);
            await _context.SaveChangesAsync();

            blogDetail.Description = blog.BlogDetail.Description;
            blogDetail.BlogsId = blogs.Id;
            await _context.BlogDetails.AddAsync(blogDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #region Update
        public IActionResult Update(int? id)
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            Blogs blogs = _context.Blogs.Include(blg => blg.BlogDetail).FirstOrDefault(blg=>blg.Id==id);
            return View(blogs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blogs blog)
        {
            ViewBag.Categ = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            if (id == null) return NotFound();

           
            Blogs blogOld = await _context.Blogs.Include(c => c.BlogDetail).FirstOrDefaultAsync(c => c.Id == id);
            Blogs isExist = _context.Blogs.Where(cr => cr.isDelete == false).FirstOrDefault(cr => cr.Id == id);
            bool exist = _context.Blogs.Where(cr => cr.isDelete == false).Any(cr => cr.Title == blog.Title);

            if (exist)
            {
                if (isExist.Title != blog.Title)
                {
                    ModelState.AddModelError("Title", "This name already has. Please write another name");
                    return View(blogOld);
                }
            }

            if (blog == null) return Content("Null");
            if (blog.Photo != null)
            {
                if (!blog.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", $"{blog.Photo.FileName} - not image type");
                    return View(blogOld);
                }

                string folder = Path.Combine("img", "blog");
                string fileName = await blog.Photo.SaveImageAsync(_env.WebRootPath, folder);
                if (fileName == null)
                {
                    return Content("Error");
                }

                Helper.DeleteImage(_env.WebRootPath, folder, blogOld.Image);
                blogOld.Image = fileName;
            }


            #region Update line
            blogOld.Title = blog.Title;
            blogOld.BlogDetail.Description = blog.BlogDetail.Description;
            blogOld.Author = blog.Author;
            #endregion

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blogs blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return RedirectToAction("ErrorPage", "Home"); ;
            Blogs blog = _context.Blogs.FirstOrDefault(c => c.Id == id);
            if (blog == null) return RedirectToAction("ErrorPage", "Home"); ;

            if (!blog.isDelete)
            {
                blog.isDelete = true;
                blog.DeletedTime = DateTime.Now;
            }
            else
                blog.isDelete = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #region EmailSender
        public async Task SenderEmail(string toEmail, string sub, string messageBody)
        {
            #region EmailSender
            var senderEmail = new MailAddress("mikayilov.muhammed.2021@gmail.com", "EduhomeAdmin Muhammed");
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

            #endregion
        }
        #endregion
    }
}
