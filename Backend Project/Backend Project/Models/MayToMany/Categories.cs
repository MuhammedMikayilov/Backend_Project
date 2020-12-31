using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public bool hasCategory { get; set; }

        public ICollection<CategoryCourse> CategoryCourses { get; set; }

    }
}
