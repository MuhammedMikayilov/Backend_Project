﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string AboutCourseDescription { get; set; }
        public string HowToApplyExplaining { get; set; }
        public string CertificationExplain { get; set; }
        public string Reply { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public List<CourseFeature> CourseFeatures { get; set; }

    }
}