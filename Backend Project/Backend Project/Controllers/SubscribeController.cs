using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Subscribe(string EmailSubscribe)
        {

            if (!EmailSubscribe.Contains("@"))
            {
                return RedirectToAction("ErrorPage", "Home");
            }

            EmailSubs email = new EmailSubs()
            {
                Email = EmailSubscribe
            };
            await _context.EmailSubs.AddAsync(email);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(CommentVM comment)
        {
            if (ModelState.IsValid)
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = comment.Email,
                        Password = comment.Password
                    }
                };
                MailAddress fromEmail = new MailAddress(comment.Email, comment.Name);
                MailAddress toEmail = new MailAddress("mikayilov.muhammed.2021@gmail.com", comment.Name);
                MailMessage message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = comment.Subject,
                    Body = comment.Message
                };
                message.To.Add(toEmail);
                client.Send(message);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
