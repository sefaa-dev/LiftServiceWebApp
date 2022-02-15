using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class CustomerManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Failure()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Failure(FailureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}
