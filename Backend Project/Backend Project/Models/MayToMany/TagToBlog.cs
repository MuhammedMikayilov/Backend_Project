using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class TagToBlog
    {
        public int Id { get; set; }
        public virtual Tags Tags { get; set; }
        public int TagsId { get; set; }
        #region Blogs
        public virtual Blogs Blogs { get; set; }
        public int BlogsId { get; set; }
        #endregion
    }
}
