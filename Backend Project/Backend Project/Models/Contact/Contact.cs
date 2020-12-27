using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Adress { get; set; }
        public string Phones { get; set; }
        public string Places { get; set; }

    }
}
