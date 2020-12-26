using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        [Required, StringLength(256)]
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string Speciality { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedTime { get; set; }

        public TeachersDetail TeachersDetail { get; set; }

    }
}
