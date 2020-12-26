using Backend_Project.Models;
//using Backend_Project.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.DAL
{
    public partial class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        #region Course
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        #endregion
        #region Notice
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Board> Boards { get; set; }
        #endregion
        #region Events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        #endregion
        #region Blogs
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        #endregion
        #region Teachers
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeachersDetail> TeachersDetails { get; set; }
        #endregion
        #region Layouts
        public DbSet<Header> Header { get; set; }
        public DbSet<Footer> Footer { get; set; }
        #endregion

        #region Categories
        public DbSet<CategoryCourse> CategoryCourses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        #endregion

        #region Tags
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagCourse> TagCourses { get; set; }

        #endregion
    }
}
