using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class EventSpeakers
    {
        public int Id { get; set; }
        public virtual Event Event { get; set; }
        public int EventId { get; set; }
        #region Speakder
        public virtual Speakers Speakers { get; set; }
        public int SpeakersId { get; set; }
        #endregion
    }
}
