using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime EventDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        //public string EventTimeLine { get; set; }

        public DateTime StartTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime EndTime { get; set; }
        public string EventPlace { get; set; }
        public bool isDelete { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public virtual EventDetails EventDetails { get; set; }
        public int EventDetailsId { get; set; }
        public ICollection<TagsToEvents> TagsToEvents { get; set; }
        public ICollection<CategoryEvents> CategoryEvents { get; set; }

    }
}
