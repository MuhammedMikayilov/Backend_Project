using Backend_Project.DAL;
using Backend_Project.Models;
//using Backend_Project.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public About About { get; set; }
        public List<Titles> Titles { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseDetail> CourseDetails { get; set; }
        public List<CourseFeature> CourseFeatures { get; set; }
        public List<Notice> Notices { get; set; }
        public List<Board> Boards { get; set; }
        public List<Event> Events { get; set; }
        public List<EventDetails> EventDetails { get; set; }
        public List<Speakers> Speakers { get; set; }

    }
}
