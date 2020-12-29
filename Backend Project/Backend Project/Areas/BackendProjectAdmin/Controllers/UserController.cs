using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Eduhome.Extentions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public UserController(UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = _userManager.Users.ToList();
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

        public async Task<IActionResult> Activation(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Activation")]
        public async Task<IActionResult> ActivationPost(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (user.isDelete)
                user.isDelete = false;
            else
                user.isDelete = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ChangePassword(string id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, ChangePassVM changePass)
        {
            if (!ModelState.IsValid) return Content("Some Problem");

            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                ModelState.AddModelError("Password", "User is undefined");
                return View();
            }

            String getPassToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            await _userManager.ResetPasswordAsync(appUser, getPassToken, changePass.Password);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeRole(string id)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            UserVM userVM = await GetUserVMAsync(user);
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string id, string role)
        {
            if (id == null || role == null) return NotFound();

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            string oldRole = (await _userManager.GetRolesAsync(user))[0];

            IdentityResult identityResult = await _userManager.AddToRoleAsync(user, role);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("", "Some problem is exist");
                UserVM userVM = await GetUserVMAsync(user);
                return View(userVM);
            }
            IdentityResult removeResult = await _userManager.RemoveFromRoleAsync(user, oldRole);
            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Some problem is exist");
                UserVM userVM = await GetUserVMAsync(user);
                return View(userVM);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return View(user);
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
                Role = (await _userManager.GetRolesAsync(user))[0],
                Roles = roles,
            };
            return userVM;
        }
    }
}
