using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        //[Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Author { get; set; }
        public DateTime DateWrite { get; set; }
        public int CommentCount { get; set; }
        public bool isDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Title { get; set; }
        public BlogDetail BlogDetail { get; set; }
        public int BlogDetailId { get; set; }
        //public ICollection<CategoryCourse> CategoryCourses { get; set; }
        public ICollection<TagToBlog> TagToBlogs { get; set; }

    }
}
