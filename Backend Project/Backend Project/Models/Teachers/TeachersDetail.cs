using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class TeachersDetail
    {
        public int Id { get; set; }

        #region About Teacher
        public string AboutMe { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string Faculty { get; set; }
        #endregion
        #region Contact Information
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Pinterest { get; set; }
        public string Vimeo { get; set; }
        public string Twitter { get; set; }
        #endregion
        #region Skills Percent
        public int Language { get; set; }
        public int Design { get; set; }
        public int TeamLeader { get; set; }
        public int Innovation { get; set; }
        public int Development { get; set; }
        public int Communication { get; set; }
        #endregion

        public Teachers Teachers { get; set; }
        [ForeignKey("Teachers")]
        public virtual int TeachersId { get; set; }
    }
}
