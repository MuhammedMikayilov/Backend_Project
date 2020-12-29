using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class EventDetails
    {
        public int Id { get; set; }
        public string EventDescription { get; set; }
        public int Count { get; set; }
        public virtual Event Event { get; set; }
        public int EventId { get; set; }
        public List<Speakers> Speakers { get; set; }

    }
}
