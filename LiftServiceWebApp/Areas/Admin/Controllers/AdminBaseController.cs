using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : Controller
    {

    }
}
