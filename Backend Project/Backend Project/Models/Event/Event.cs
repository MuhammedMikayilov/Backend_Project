using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string EventTimeLine { get; set; }
        public string EventPlace { get; set; }
        public bool isDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public virtual EventDetails EventDetails { get; set; }
        public int EventDetailsId { get; set; }

    }
}
