using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string Author { get; set; }
        public DateTime DateWrite { get; set; }
        public int CommentCount { get; set; }
        public bool isDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string Title { get; set; }
        public BlogDetail Detail { get; set; }
        public int DetailId { get; set; }

    }
}
