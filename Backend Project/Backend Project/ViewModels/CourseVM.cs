﻿using Backend_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewModels
{
    public class CourseVM
    {
        public List<Categories> Categories { get; set; }
        public Course Course { get; set; }
    }
}
