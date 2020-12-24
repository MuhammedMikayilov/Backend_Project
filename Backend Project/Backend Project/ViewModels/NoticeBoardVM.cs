using Backend_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project.ViewModels
{
    public class NoticeBoardVM
    {
        public Notice Notices { get; set; }
        public List<Board> Boards { get; set; }
    }
}
