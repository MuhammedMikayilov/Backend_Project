using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class TagsToEvents
    {
        public int Id { get; set; }
        public Tags Tags { get; set; }
        public int TagsId { get; set; }
        public Event Events { get; set; }
        public int EventsId { get; set; }   
    }
}
