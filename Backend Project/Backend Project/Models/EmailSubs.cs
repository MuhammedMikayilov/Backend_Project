using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.Models
{
    public class EmailSubs
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
