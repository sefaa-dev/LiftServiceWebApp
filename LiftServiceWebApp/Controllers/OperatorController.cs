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
        // Arızaları Görüntüleme
        public async Task<IActionResult> Failures()
        {
            // Arızalar
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _dbContext.Failures.Where(x => x.TechnicianId == null).ToList();

            // Teknisyenler
            var technicians = await _userManager.GetUsersInRoleAsync("Technician");
            List<TechnicianAssignViewModel> technicianList = new List<TechnicianAssignViewModel>();
            foreach (var item in technicians)
            {
                TechnicianAssignViewModel technicianAssignViewModel = new TechnicianAssignViewModel
                {
                    TechnicianId = item.Id,
                    TechnicianName = $"{item.Name} {item.Surname}"
                };
                technicianList.Add(technicianAssignViewModel);
            }
            ViewBag.Technicians = technicianList;
            return View(failures);
        }

        //[HttpPost]
        //public async Task<IActionResult> Failures(List<IssueAssignViewModel> issueAssignViewModels)
        //{

        //    return View(issueAssignViewModels);
        //}



        // Teknisyen Atama
        public IActionResult TechnicianAssign(TechnicianAssignViewModel technicianAssignViewModel)
        {
            var item = technicianAssignViewModel;
            return View(item);
        }

        //[HttpPost]
        //public IActionResult TechnicianAssign(List<TechnicianAssignViewModel> technicianAssignViewModels)
        //{
        //    //var issue = issueAssignViewModel.FirstOrDefault();
        //    //if (issue == null)
        //    //    return View();
        //    //Failure failure = _dbContext.Failures.Where(x => x.Id.ToString() == issue.FailureId).Single();
        //    return View();
        //}
    }
}