using Backend_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class TeachersViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public TeachersViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? take)
        {

            return View(await Task.FromResult(_context.Teachers.Where(tc => tc.IsDelete == false).Take((int)take).ToList()));
        }
    }
}
