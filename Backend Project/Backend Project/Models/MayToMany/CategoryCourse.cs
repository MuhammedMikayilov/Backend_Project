using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class CategoryCourse
    {
        public int Id { get; set; }
        public virtual Categories Categories { get; set; }
        public int CategoriesId { get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        
    }
}
