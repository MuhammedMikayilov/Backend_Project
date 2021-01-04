using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
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
    [Authorize(Roles = "Member")]
    public class SimpleUserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;


        public SimpleUserController(UserManager<AppUser> userManager, IWebHostEnvironment env, AppDbContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _env = env;
            _context = context;
            _signInManager = signInManager;
        }
        #region Index
        public IActionResult Index()
        {
            AppUser user = _context.Users.Where(us => us.UserName == User.Identity.Name).FirstOrDefault();
            return View(user);
        }
        #endregion
        #region Change Passwoar
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
        #endregion

        #region Update User
        public IActionResult UpdateUser(string id)
        {
            if (id == null) return NotFound();
            AppUser user = _userManager.Users.FirstOrDefault(c => c.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(string id, AppUser userNewParam)
        {
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            //UserVM userVM = await GetUserVMAsync(user);

            #region check username
            bool isExistUserName = _userManager.Users.Where(us => us.isDelete == false).Any(us => us.UserName == userNewParam.UserName);
            AppUser hasUserName = _userManager.Users.Where(us => us.isDelete == false).FirstOrDefault(us => us.Id == id);
            if (isExistUserName)
            {
                if (hasUserName.UserName != userNewParam.UserName)
                {
                    ModelState.AddModelError("UserName", "This username already exist. Please use another username");
                    return View();
                }

            }
            #endregion
            #region Check email
            bool isExistEmail = _userManager.Users.Any(us => us.Email == userNewParam.Email);
            AppUser hasEmail = _userManager.Users.Where(us => us.isDelete == false).FirstOrDefault(us => us.Id == id);
            if (isExistEmail)
            {
                if (hasEmail.Email != userNewParam.Email)
                {
                    ModelState.AddModelError("Email", "This Email already exist. Please use another username");
                    return View();
                }
            }
            #endregion

            user.Firstname = userNewParam.Firstname;
            user.Lastname = userNewParam.Lastname;
            user.Email = userNewParam.Email;
            user.UserName = userNewParam.UserName;
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, true);


            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
