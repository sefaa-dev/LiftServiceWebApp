using Microsoft.AspNetCore.Mvc;
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
            //var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            //var failures = _dbContext.Failures.Where(x => x.UserId == user.Id).ToList();
            //List<FailureViewModel> failuresViewModels = new List<FailureViewModel>();
            //foreach (Failure item in failures)
            //{
            //    var failureViewModel = new FailureViewModel()
            //    {
            //        FailureName = item.FailureName,
            //        FailureDescription = item.FailureDescription,
            //        AddressDetail = item.AddressDetail,
            //        FailureState = FailureStates.Alındı,
            //        Latitude = item.Latitude,
            //        Longitude = item.Longitude
            //    };
            //    failuresViewModels.Add(failureViewModel);
            //}
            return View();
        }

    }
}
