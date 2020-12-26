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
        #region Course
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        #endregion

        //#region Blogs
        //public virtual Blogs Blogs { get; set; }
        //public int BlogsId { get; set; }
        //#endregion


    }
}
