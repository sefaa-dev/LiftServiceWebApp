using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Areas.Admin.Controllers
{
    public class AddressApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
