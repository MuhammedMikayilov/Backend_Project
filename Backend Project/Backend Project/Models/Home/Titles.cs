using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Titles
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
