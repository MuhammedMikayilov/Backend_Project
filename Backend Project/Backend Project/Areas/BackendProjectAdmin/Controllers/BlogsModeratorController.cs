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
    [Authorize(Roles = "Admin, BlogsWriter")]
    public class BlogsModeratorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<AppUser> _signInManager;

        public BlogsModeratorController(UserManager<AppUser> userManager,
            IWebHostEnvironment env,
            AppDbContext context,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _env = env;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = _userManager.Users.Where(u => u.isDelete == false).ToList();
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

        #region CRUD
        #region Create User
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser()
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                UserName = register.Username,
                Email = register.Email
            };
            #region check username
            bool isExistUserName = _userManager.Users.Where(us => us.isDelete == false && User.IsInRole("BlogsWriter")).Any(us => us.UserName == newUser.UserName);
            if (isExistUserName)
            {
                ModelState.AddModelError("", "This username already exist. Please use another username");
                return View();
            }
            #endregion

            #region Check email
            bool isExistEmail = _userManager.Users.Where(us => us.isDelete == false && User.IsInRole("BlogsWriter")).Any(us => us.Email == newUser.Email);
            if (isExistEmail)
            {
                ModelState.AddModelError("", "This Email already exist. Please use another username");
                return View();
            }
            #endregion

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, Roles.BlogsWriter.ToString());
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Activation

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
        #endregion

        #region Change Passwoard
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

            UserVM userVM = await GetUserVMAsync(user);

            #region check username
            bool isExistUserName = _userManager.Users.Where(us => us.isDelete == false || User.IsInRole("BlogsWriter")).Any(us => us.UserName == userNewParam.UserName);
            AppUser hasUserName = _userManager.Users.Where(us => us.isDelete == false || User.IsInRole("BlogsWriter")).FirstOrDefault(us => us.Id == id);
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
            bool isExistEmail = _userManager.Users.Where(us => us.isDelete == false || User.IsInRole("BlogsWriter")).Any(us => us.Email == userNewParam.Email);
            AppUser hasEmail = _userManager.Users.Where(us => us.isDelete == false || User.IsInRole("BlogsWriter")).FirstOrDefault(us => us.Id == id);
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

        #region Change Role
        public async Task<IActionResult> ChangeRole(string id)
        {
            if (id == null) return RedirectToAction("ErrorPage", "Home");
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
        #endregion

        public async Task<IActionResult> Detail(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        private async Task<UserVM> GetUserVMAsync(AppUser user)
        {
            List<string> roles = new List<string> { Roles.Admin.ToString(), Roles.CourseModerator.ToString(),
                Roles.EventModerator.ToString(), Roles.BlogsWriter.ToString(), Roles.Member.ToString() };
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

        #endregion
    }
}
