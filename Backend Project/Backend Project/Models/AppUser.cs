using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string Firstname { get; set; } 
        public string Lastname { get; set; }
        public bool isDelete { get; set; }
    }
}
