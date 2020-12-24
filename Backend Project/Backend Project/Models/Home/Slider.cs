using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, StringLength(256)]
        public string Image { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
