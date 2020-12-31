using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public bool hasTags { get; set; }

        public ICollection<TagCourse> TagCourses { get; set; }

    }
}
