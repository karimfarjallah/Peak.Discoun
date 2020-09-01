using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Peak.Discoun.Areas.Admin.Controllers
{
   
    public class LoginController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
