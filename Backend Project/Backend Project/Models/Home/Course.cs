﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual CourseDetail CourseDetail { get; set; }
        public int CourseDetailId { get; set; }
    }
}