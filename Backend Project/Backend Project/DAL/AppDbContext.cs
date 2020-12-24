using Backend_Project.Models;
//using Backend_Project.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Footer> Footer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(cD => cD.CourseDetail)
                .WithOne(c => c.Course)
                .HasForeignKey<CourseDetail>(cD => cD.CourseId);

            modelBuilder.Entity<Event>()
                .HasOne(eD=>eD.EventDetails)
                .WithOne(e => e.Event)
                .HasForeignKey<EventDetails>(eD => eD.EventId);

            modelBuilder.Entity<Blogs>()
                .HasOne(bD => bD.Detail)
                .WithOne(b => b.Blogs)
                .HasForeignKey<BlogDetail>(bD => bD.BlogsId);
        }

    }
}
