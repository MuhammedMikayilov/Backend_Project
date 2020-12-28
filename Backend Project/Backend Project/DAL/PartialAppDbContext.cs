using Backend_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.DAL
{
    public partial class AppDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(cD => cD.CourseDetail)
                .WithOne(c => c.Course)
                .HasForeignKey<CourseDetail>(cD => cD.CourseId);

            modelBuilder.Entity<Event>()
                .HasOne(eD => eD.EventDetails)
                .WithOne(e => e.Event)
                .HasForeignKey<EventDetails>(eD => eD.EventId);

            modelBuilder.Entity<Blogs>()
                .HasOne(bD => bD.Detail)
                .WithOne(b => b.Blogs)
                .HasForeignKey<BlogDetail>(bD => bD.BlogsId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
