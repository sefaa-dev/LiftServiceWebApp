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
        public async Task<IActionResult> IssueAssign()
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
                    FailureState = FailureStates.Alındı
                };
                // Teknisyen null gelince Technician.Name ve Technician.Surname null reference hatası veriyor
                // Bunu engellemek için if else yazıldı
                if (Technician == null)
                {
                    issueAssignViewModel.TechnicianName = null;
                }
                else
                {
                    issueAssignViewModel.TechnicianName = $"{Technician.Name} {Technician.Surname}";
                }
                issueAssignViewModels.Add(issueAssignViewModel);
            }
            return View(issueAssignViewModels);
        }

        //[HttpPost]
        //public async Task<IActionResult> IssueAssignAsync(string FailureId)
        //{

        //    var failure = await _dbContext.Failures.FindAsync(FailureId);
        //    failure.FailureState = FailureStates.TeknisyenAtandı;
        //}



    }
}
