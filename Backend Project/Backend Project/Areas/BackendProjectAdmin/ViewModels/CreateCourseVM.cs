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
        public Course Course { get; set; }
        public Event Event { get; set; }
        public Blogs Blogs { get; set; }



    }
}
