using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required, MaxLength(80)]
        public string CourseName { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public bool isDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public virtual CourseDetail CourseDetail { get; set; }
        public int CourseDetailId { get; set; }
        public ICollection<CategoryCourse> CategoryCourses { get; set; }
        public ICollection<TagCourse> TagCourses { get; set; }
        //public IFormFile Photo { get; set; }


    }
}
