using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Bios
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
        public string Twitter { get; set; }

        //Header us
        [Required]
        public string HeaderLogo { get; set; }
        [NotMapped]
        public IFormFile PhotoHeader { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Number { get; set; }

        //About us
        [Required]
        public string Address { get; set; }
        public string Place { get; set; }
        public string Phono1 { get; set; }
        public string Phone2 { get; set; }
        public string EmailUs { get; set; }
        public string OurSite { get; set; }
    }
}
