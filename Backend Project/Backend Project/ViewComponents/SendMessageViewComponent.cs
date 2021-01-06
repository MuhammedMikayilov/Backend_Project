using Backend_Project.DAL;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class SendMessageViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public SendMessageViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CommentVM comment = new CommentVM();
            return View(await Task.FromResult(comment));
        }
    }
}
