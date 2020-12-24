using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class BlogDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual Blogs Blogs { get; set; }
        public int BlogsId { get; set; }

    }
}
