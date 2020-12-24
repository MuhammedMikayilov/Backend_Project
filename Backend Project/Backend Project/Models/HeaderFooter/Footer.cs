using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Footer
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
        public string Twitter { get; set; }

        //About us
        [Required]
        public string Address { get; set; }
        public string Phono1 { get; set; }
        public string Phone2 { get; set; }
        public string EmailUs { get; set; }
        public string OurSite { get; set; }
    }
}
