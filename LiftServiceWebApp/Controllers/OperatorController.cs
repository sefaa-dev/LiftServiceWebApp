﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class OperatorController : Controller
    {
        public IActionResult IssueAssign()
        {
            return View();
        }

    }
}
