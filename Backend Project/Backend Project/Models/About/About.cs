﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool isDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
