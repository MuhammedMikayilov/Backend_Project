using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class CategoryEvents
    {
        public int Id { get; set; }
        public virtual Categories Categories { get; set; }
        public int CategoriesId { get; set; }

        public virtual Event Event { get; set; }
        public int EventId { get; set; }
    }
}
