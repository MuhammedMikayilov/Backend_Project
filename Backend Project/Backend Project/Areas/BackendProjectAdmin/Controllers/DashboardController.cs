using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Project.Areas.BackendProjectAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("BackendProjectAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
