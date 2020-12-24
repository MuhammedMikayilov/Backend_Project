using Backend_Project.DAL;
using Backend_Project.Models;
using Backend_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewComponents
{
    public class EventsViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public EventsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? take)
        {
            List<Event> events = new List<Event>();
            events = _context.Events.Where(b => b.isDelete == false).Take((int)take).ToList();
            return View(await Task.FromResult(events));
        }
    }
}
