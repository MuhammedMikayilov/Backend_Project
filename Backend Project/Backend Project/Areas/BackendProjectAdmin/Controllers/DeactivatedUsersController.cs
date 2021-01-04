using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
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
    public class DeactivatedUsersController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;


        public DeactivatedUsersController(UserManager<AppUser> userManager, IWebHostEnvironment env, AppDbContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _env = env;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = _userManager.Users.Where(u=>u.isDelete==true)
                .OrderByDescending(us=>us.Firstname).ToList();
            List<UserVM> usersVM = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM()
                {
                    Id = user.Id,
                    Name = user.Firstname,
                    Lastname = user.Lastname,
                    Username = user.UserName,
                    Email = user.Email,
                    IsDelete = user.isDelete,
                    Role = (await _userManager.GetRolesAsync(user))[0],
                };

                usersVM.Add(userVM);
            }
            return View(usersVM);
        }
    }
}
