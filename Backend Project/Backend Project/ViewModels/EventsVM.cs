using Backend_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewModels
{
    public class EventsVM
    {
        public List<Blogs> Blogs { get; set; }
        public Event Event { get; set; }
    }
}
