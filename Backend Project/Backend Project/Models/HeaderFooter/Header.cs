using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Header
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        public string Number { get; set; }


    }
}
