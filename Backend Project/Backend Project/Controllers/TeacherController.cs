using Backend_Project.DAL;
using Backend_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page = 1)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Teachers
               .Where(blg => blg.IsDelete == false).Count() / 12);
            ViewBag.Page = page;
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();

            Teachers teachers = _context.Teachers.Where(tc=>tc.IsDelete == false)
                .Include(teach=>teach.TeachersDetail).FirstOrDefault(teach=>teach.Id == id);

            return View(teachers);
        }
    }
}
