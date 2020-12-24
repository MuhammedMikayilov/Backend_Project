﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Speakers
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string SpeakerName { get; set; }
        public string Position { get; set; }
        public virtual EventDetails EventDetails { get; set; }
        public int EventDetailsId { get; set; }
    }
}