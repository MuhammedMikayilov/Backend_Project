using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class CategoryBlogs
    {
        public int Id { get; set; }
        public virtual Categories Categories { get; set; }
        public int CategoriesId { get; set; }

        public virtual Blogs Blogs { get; set; }
        public int BlogsId { get; set; }
    }

}
