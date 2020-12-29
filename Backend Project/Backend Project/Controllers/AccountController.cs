using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Eduhome.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AccountController(
                                AppDbContext context,
                                UserManager<AppUser> userManager, 
                                SignInManager<AppUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email or Password wrong!");
                return View();
            }
            if (user.isDelete)
            {
                ModelState.AddModelError("Email", "This account blocked!");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult inResult = 
                await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

            if (inResult.IsLockedOut)
            {
                ModelState.AddModelError("Email", "Try after a few minutes");
                return View(login);
            }

            if (!inResult.Succeeded)
            {
                ModelState.AddModelError("Password", "Email or password wrong!!!");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser()
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                UserName = register.Username,
                Email = register.Email
            };

            IdentityResult identityResult =  await _userManager.CreateAsync(newUser, register.Password);

            if (!identityResult.Succeeded)
            {
                return View();
            }

            //await _userManager.AddToRoleAsync(newUser, Roles.Admin.ToString());
            await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region Roles
        //public async Task CreateUserRole()
        //{
        //    if (!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("CourseModerator"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "CourseModerator" });
        //    }
        //    if (!await _roleManager.RoleExistsAsync("TeacherModerator"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "TeacherModerator" });

        //    }
        //    if (!await _roleManager.RoleExistsAsync("EventModerator"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "EventModerator" });

        //    }
        //    if (!await _roleManager.RoleExistsAsync("Member"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    }


        //}
        #endregion
    }
}
