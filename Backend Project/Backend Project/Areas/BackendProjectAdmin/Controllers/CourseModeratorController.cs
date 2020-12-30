using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Eduhome.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    [Area("BackendProjectAdmin")]
    public class CourseModeratorController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public CourseModeratorController(UserManager<AppUser> userManager, IWebHostEnvironment env, AppDbContext context)
        {
            _userManager = userManager;
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            //AppUser appUser = _userManager.Users.FirstOrDefault(us;

            //return View(_userManager.Users.Where(u => u.Role == );
            return View();
        }



        private async Task<UserVM> GetUserVMAsync(AppUser user)
        {
            List<string> roles = new List<string> { Roles.Admin.ToString(), Roles.CourseModerator.ToString(),
                Roles.EventModerator.ToString(), Roles.TeacherModerator.ToString(), Roles.Member.ToString() };
            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Name = user.Firstname,
                Lastname = user.Lastname,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Roles = roles,
            };
            return userVM;
        }
    }
}
