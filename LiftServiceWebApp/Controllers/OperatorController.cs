using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class OperatorController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OperatorController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> IssueAssignAsync()
        {

            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _dbContext.Failures.Where(x => x.UserId == user.Id).ToList();
            List<IssueAssignViewModel> issueAssignViewModels = new List<IssueAssignViewModel>();
            foreach(Failure item in failures)
            {
                ApplicationUser Technician = await _userManager.FindByIdAsync(item.TechnicianId);
                var issueAssignViewModel = new IssueAssignViewModel()
                {
                    FailureName = item.FailureName,
                    CreatedDate = item.CreatedDate,
                    FailureState = FailureStates.Alındı,
                    TechnicianName = $"{Technician.Name} {Technician.Surname}",
                };
                issueAssignViewModels.Add(issueAssignViewModel);
            }
            return View(issueAssignViewModels);
        }

    }
}
