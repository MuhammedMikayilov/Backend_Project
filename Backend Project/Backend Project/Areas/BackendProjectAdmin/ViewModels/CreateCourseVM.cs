using Backend_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Areas.BackendProjectAdmin.ViewModels
{
    public class CreateCourseVM
    {
        //public List<Tags> Tags { get; set; }
        //public List<Categories> Categories { get; set; }
        public Course Course { get; set; }

        //[Required]
        //public string Image { get; set; }
        //[Required, MaxLength(80)]
        //public string CourseName { get; set; }
        //[Required]
        //public string CourseDescription { get; set; }
        //[NotMapped]
        //public IFormFile Photo { get; set; }

    }
}
