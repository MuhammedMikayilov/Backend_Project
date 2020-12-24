using Backend_Project.DAL;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class NoticeViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public NoticeViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM homeVM = new HomeVM
            {
                Notices = _context.Notices.FirstOrDefault(),
                Boards = _context.Boards.ToList(),
            };
            return View(await Task.FromResult(homeVM));
        }
    }
}
