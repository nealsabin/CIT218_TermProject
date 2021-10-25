using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Controllers
{
    public class DifficultyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
