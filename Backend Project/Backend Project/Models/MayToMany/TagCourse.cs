﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class TagCourse
    {
        public int Id { get; set; }
       
        public virtual Tags Tags { get; set; }
        public int TagsId { get; set; }

        #region Course
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        #endregion

        
    }
}
